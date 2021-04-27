using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TesteDa
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instância da Classe que contém o DataTable
            Table table = new Table();

            //Laço infinito que só para quando a opção "2" e digitada
            while (true)
            {
                Console.WriteLine("Digite a opção desejada: ");
                Console.WriteLine("1 - Cadastrar\t2 - Entrar\t3 - Sair");
                string verify = Console.ReadLine().Trim().ToUpper();

                if (verify == "1") //Opção "Cadastrar"
                {
                    if(Cadastro(table))
                    {
                        Console.WriteLine("CADASTRO REALIZADO COM SUCESSO!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("ERRO AO EFETUAR CADASTRO!!!\n");
                    }
                }
                else if (verify == "2") //Opção "Entrar"
                {
                    if(ConfirmLogin(table))
                    {
                        Console.WriteLine("LOGADO COM SUCESSO!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("ERRO A EFETUAR LOGIN!!!\n");
                    }
                }
                else
                {
                    //Serializa a Tabela e armazena os dados em um
                    //arquivo .xml
                    table.Save();
                    break;
                }

            }
        }

        private static bool Cadastro(Table table)
        {
            Console.Write("id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("user: ");
            string user = Console.ReadLine();
            Console.Write("password: ");
            string password = Console.ReadLine();
            Console.Write("coins: ");
            int coins = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            //O método estático GetInstance() garante apenas uma instância da
            //Classe "User" para economizar memória
            User usuario = User.GetInstance(id, user, password, coins);

            try
            {
                table.AddRow(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        private static bool ConfirmLogin(Table table)
        {
            Hash hash = new Hash(SHA512.Create());

            Console.Write("Username: ");
            string login = Console.ReadLine().Trim();
            Console.Write("Senha: ");
            string senha = Console.ReadLine().Trim();

            var consulta = from p in table.dt.AsEnumerable()
                           select new
                           {
                               username = p.Field<string>("user"),
                               password = p.Field<string>("password"),
                           };

            foreach (var user in consulta)
            {
                
                if (user.username == login && hash.VerificarSenha(senha, user.password))
                {
                    return true;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// Classe com todas a propriedades necessárias para o cadastro de usuário
    /// </summary>
    public class User
    {
        #region "Singleton - Pattern"

        //Armazena apenas a primeira instância
        private static User instance;

        //Construtor personalizado privado que recebe os dados necessários para o cadastro
        private User(int id, string user, string password, int coins)
        {
            this.id = id;
            this.user = user;
            this.password = password;
            this.coins = coins;
        }

        /// <summary>
        /// Método para garantir apenas uma instância.
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="user">username</param>
        /// <param name="password">senha - OBS.: Criptografar</param>
        /// <param name="coins">Quantidade inicial de moedas</param>
        /// <returns>Instância da Classe User</returns>
        public static User GetInstance(int id, string user, string password, int coins)
        {
            //Verifica se a variável "instance" já contém alguma instância
            if (instance == null) //Não existe
            {
                //Retorna uma nova instância
                return new User(id, user, password, coins);
            }
            else //Existe
            {
                //Seta as propriedades
                instance.id = id;
                instance.user = user;
                instance.password = user;
                instance.coins = coins;
            }

            //Retorna a instância já existente
            return instance;
        }

        #endregion

        public int id;
        public string user;
        public string password;
        public int coins;
    }

    /// <summary>
    /// Classe que contém os o DataTable e os métodos que o manipulam
    /// </summary>
    public class Table
    {
        //Tabela com os usuários e seus dados
        public DataTable dt;

        //Verifica se o arquivo .xml existe.
        //Se sim => desserializa o arquivo e seta a tabela
        //Se não => Cria uma nova tabela com os campos necessários
        private void VerifyDataTableExists()
        {
            if (File.Exists("usuarios.xml"))
            {
                //Captura os dados necessários
                FileStream stream = new FileStream("usuarios.xml", FileMode.Open);
                XmlSerializer desserializador = new XmlSerializer(typeof(DataTable));
                dt = (DataTable)desserializador.Deserialize(stream);
                stream.Close();
            }
            else //Cria as colunas necessárias
            {
                //Seta o nome da tabela
                dt = new DataTable("usuarios");

                //Seta as colunas
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("user", typeof(string));
                dt.Columns.Add("password", typeof(string));
                dt.Columns.Add("coins", typeof(int));
            }
        }

        //Construtor personalizado
        public Table()
        {
            VerifyDataTableExists();
        }

        /// <summary>
        /// Adiciona o usuário e seus dados na tabela
        /// </summary>
        /// <param name="user">Objeto User</param>
        public void AddRow(User user)
        {
            Hash hash = new Hash(SHA512.Create());

            dt.Rows.Add(user.id, user.user, hash.CriptografarSenha(user.password), user.coins);
        }

        /// <summary>
        /// Serializa o objeto DataTable para salvar os dados para a 
        /// próxima  vez que o programa for aberto
        /// </summary>
        public void Save()
        {
            //Serializa o objeto
            FileStream stream = new FileStream("usuarios.xml", FileMode.Create);
            XmlSerializer serializador = new XmlSerializer(typeof(DataTable));
            serializador.Serialize(stream, dt);
            stream.Close();
        }

    }

    /// <summary>
    /// Criptografia da Senha
    /// </summary>
    public class Hash
    {
        private HashAlgorithm _algoritmo;

        public Hash(HashAlgorithm algoritmo)
        {
            _algoritmo = algoritmo;
        }

        public string CriptografarSenha(string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = _algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool VerificarSenha(string senhaDigitada, string senhaCadastrada)
        {
            if (string.IsNullOrEmpty(senhaCadastrada))
                throw new NullReferenceException("Cadastre uma senha.");

            var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

            var sb = new StringBuilder();
            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }

            return sb.ToString() == senhaCadastrada;
        }
    }
}

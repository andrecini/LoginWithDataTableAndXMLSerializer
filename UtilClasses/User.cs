using System;

namespace UtilClasses
{
    public class User
    {
        #region "Singleton - Pattern"

        //Armazena apenas a primeira instância
        private static User instance;

        /// <summary>
        /// Método para garantir apenas uma instância.
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="user">username</param>
        /// <param name="password">senha - OBS.: Criptografar</param>
        /// <param name="coins">Quantidade inicial de moedas</param>
        /// <returns>Instância da Classe User</returns>
        public static User GetInstance(string username, string password)
        {
            //Verifica se a variável "instance" já contém alguma instância
            if (instance == null) //Não existe
            {                
                //Retorna uma nova instância
                return new User();
            }

            instance.Username = username;
            instance.Password = password;

            //Retorna a instância já existente
            return instance;
        }

        public static User GetInstance()
        {
            //Verifica se a variável "instance" já contém alguma instância
            if (instance == null) //Não existe
            {
                //Retorna uma nova instância
                return new User();
            }

            //Retorna a instância já existente
            return instance;
        }

        #endregion

        private string username;
        private string password;
        private const int coins = 1000;

        public string Username
        {
            get => username;
            set
            {
                if (value == null || value == string.Empty)
                    throw new Exception("O Login não pode ser nulo.");
                else
                    username = value;
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (value == null || value == string.Empty)
                    throw new Exception("A senha não pode ser nula.");
                if (value.Length < 8)
                    throw new Exception("A senha deve ter no mínimo 10 caracteres.");
                else
                    password = value;
            }
        }

        public int Coins
        {
            get => coins;
        }
    }
}

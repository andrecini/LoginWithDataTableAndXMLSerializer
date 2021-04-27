using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilClasses;

namespace frmLogin
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Table table = Table.GetInstance();
            
            try
            {
                if (txtSenha1.Text == txtSenha2.Text)
                {
                    User user = User.GetInstance();

                    user.Username = txtUsername.Text;
                    user.Password = txtSenha1.Text;

                    table.AddRow(user);

                    table.Save();

                    MessageBox.Show("Cadastro realizado com sucesso!!!");
                }
                else
                {
                    MessageBox.Show("A senhas não coincidem!!!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

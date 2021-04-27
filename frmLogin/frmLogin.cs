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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {
            try
            {
                User user = User.GetInstance();
                user.Username = txtUsername.Text;
                user.Password = txtPassword.Text;

                Table table = Table.GetInstance();

                if (table.VerifyLogin(user.Username, user.Password))
                {

                    MessageBox.Show("Login efetuado com sucesso!!!");
                }
                else
                    MessageBox.Show("Login efetuado com sucesso!!!");


            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            
        }

        private void tsbRegister_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.ShowDialog();
        }
    }
}

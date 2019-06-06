using br.com.livrariashalom.BLL;
using br.com.livrariashalom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace br.com.livrariashalom.View
{
    /// <summary>
    /// Lógica interna para TelaLogin.xaml
    /// </summary>
    public partial class TelaLogin : Window
    {
        private LoginFuncionarioBLL loginFuncionarioBLL = new LoginFuncionarioBLL();
        private LoginFuncionario loginFuncionario = new LoginFuncionario();

        public TelaLogin()
        {
            InitializeComponent();
        }

        private bool Logar()
        {
            try
            {
                if (txtFuncionario.Text == "" || pswSenha.Password == "")
                {
                    MessageBox.Show("Campos usuário e/ou senha vazios");
                }
                else
                {
                    loginFuncionario.Funcionario = txtFuncionario.Text;
                    loginFuncionario.Senha = pswSenha.Password;
                    loginFuncionarioBLL.Logar(loginFuncionario);
                    return true;
                }

                return false;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void BtnLogar_Click(object sender, RoutedEventArgs e)
        {
            Logar();
            this.Close();
        }
    }
}

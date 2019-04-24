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
    /// Lógica interna para Usuario.xaml
    /// </summary>
    public partial class TelaFuncionario : Window 
    {
        private LoginFuncionarioBLL funcionarioBLL = new LoginFuncionarioBLL();

        public TelaFuncionario()
        {
            InitializeComponent();
        }


        //caso a confirmação de senha não esteja igual e 
        private bool ValidarSenha()
        {
            if (pswSenha.Password != pswConfSenha.Password || pswConfSenha.Password != pswSenha.Password)
            {
                MessageBox.Show("Senhas não são iguais");
                pswSenha.Focus();
            }
            else if (pswSenha.Password.Length > 15)//caso ela tenha mais de 15 caracteres
            {
                MessageBox.Show("Não é permitido senhas acima de 15 caracteres");
            }

            return false;
        }

        public bool SalvarFuncionario(LoginFuncionario loginFuncionario)
        {
            try
            {
                //caso os campos estiverem vazios
                if (txtFuncionario.Text == "" || pswSenha.Password == "" || pswConfSenha.Password == "" || cmbTipoFuncionario.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {

                    loginFuncionario.Funcionario = txtFuncionario.Text;
                    loginFuncionario.Senha = pswSenha.Password;
                    loginFuncionario.ConfSenha = pswSenha.Password;

                    if (ValidarSenha() == false)
                    {
                        pswSenha.Focus();
                    }
                    
                    loginFuncionario.TipoFuncionario = cmbTipoFuncionario.Text;
                    funcionarioBLL.SalvarFuncionario(loginFuncionario);

                    MessageBox.Show("Cadastro feito com sucesso");
                    return true;
                }
                return false;
            }

            catch (Exception error)
            {
                throw error;
            }
        }


        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            LoginFuncionario loginFuncionario = new LoginFuncionario();
            SalvarFuncionario(loginFuncionario);
        }

        private void PswSenha_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }

        private void PswConfSenha_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }
    }

}

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
            ListarFuncionario();
        }

        //limpa os valores após uma ação
        private void Limpar()
        {
            txtFuncionario.Clear();
            pswSenha.Clear();
            pswConfSenha.Clear();
            cmbTipoFuncionario.SelectedIndex = 0;
            
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
        //salvar
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
                    loginFuncionario.TipoFuncionario = cmbTipoFuncionario.Text;

                    if (ValidarSenha() == false)
                    {
                        pswSenha.Focus();
                    }
                    
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

        //editar funcionario
        public bool EditarFuncionario(LoginFuncionario loginFuncionario)
        {
            try
            {
                //caso os campos estiverem vazios
                if ( txtFuncionario.Text == "" || pswSenha.Password == "" || pswConfSenha.Password == "" || cmbTipoFuncionario.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    loginFuncionario.Funcionario = txtFuncionario.Text;
                    loginFuncionario.Senha = pswSenha.Password;
                    loginFuncionario.ConfSenha = pswSenha.Password;
                    loginFuncionario.TipoFuncionario = cmbTipoFuncionario.Text;

                    MessageBoxResult alteracao = MessageBox.Show("Deseja realmete salvar as alterações ?", "Editar", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (alteracao == MessageBoxResult.Yes)
                    {
                        funcionarioBLL.ExcluirFuncionario(loginFuncionario);

                        MessageBox.Show("Edição feito com sucesso");
                        Limpar();
                        return true;
                    }
   
                }
                return false;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        //excluir funcionario
        public bool ExcluirFuncionario(LoginFuncionario loginFuncionario)
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
                    loginFuncionario.TipoFuncionario = cmbTipoFuncionario.Text;

                    MessageBoxResult excluir = MessageBox.Show("Deseja realmete salvar as alterações ?", "Editar", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (excluir == MessageBoxResult.Yes)
                    {
                        funcionarioBLL.ExcluirFuncionario(loginFuncionario);

                        MessageBox.Show("Cadastro feito com sucesso");
                        Limpar();
                        return true;
                    }

                }
                return false;
            }

            catch (Exception error)
            {
                throw error;
            }
        }

        //ListarFornecedor lista todos os funcionarios
        private void ListarFuncionario()
        {
            try
            {
                dgFuncionario.ItemsSource = funcionarioBLL.ListarFuncionario().DefaultView;//obtém todos os dados
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
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

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            LoginFuncionario login = new LoginFuncionario();
            EditarFuncionario(login);
        }

        private void CmbTipoFuncionario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String tipo = cmbTipoFuncionario.SelectedValue.ToString();
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            LoginFuncionario loginFuncionario = new LoginFuncionario();
            ExcluirFuncionario(loginFuncionario);
        }
    }

}

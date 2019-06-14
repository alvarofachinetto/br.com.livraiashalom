using br.com.livrariashalom.BLL;
using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
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
        MySqlCommand command = null;
        Conexao conexao = new Conexao();

        public TelaLogin()
        {
            InitializeComponent();
        }

        //metodo para entrar no sistema 
        public void Logar()
        {
            try
            {

                conexao.Conectar();
                command = new MySqlCommand("select usuario, senha, tipo_usuario from loginfuncionario where usuario = @usuario and senha = @senha", conexao.conexao);
                command.Parameters.AddWithValue("@usuario", txtFuncionario.Text);
                command.Parameters.AddWithValue("@senha", pswSenha.Password);

                MySqlDataReader dr = command.ExecuteReader();

                //verifica a informação no banco
                if (dr.Read())
                {
                    string user = dr["tipo_usuario"].ToString();

                    if (user.Equals("Usuario"))
                    {
                        TelaPrincipal telaPrincipal = new TelaPrincipal();
                        telaPrincipal.menuItemFuncionario.IsEnabled = false;
                        telaPrincipal.menuItemPagarContas.IsEnabled = false;
                        telaPrincipal.menuItemReceberContas.IsEnabled = false;
                        telaPrincipal.menuVenda.IsEnabled = false;

                        MessageBox.Show("Welcome !");

                        telaPrincipal.Show();
                        this.Close();
                    }
                    else if (user.Equals("Administrador"))
                    {

                        MessageBox.Show("Welcome !");

                        TelaPrincipal telaPrincipal = new TelaPrincipal();
                        telaPrincipal.Show();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Usuario/Senha incorretos!");
                }

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void BtnLogar_Click(object sender, RoutedEventArgs e)
        {
            Logar();
        }
    }
}

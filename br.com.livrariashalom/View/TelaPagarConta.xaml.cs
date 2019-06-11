using br.com.livrariashalom.BLL;
using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para TelaPagarConta.xaml
    /// </summary>
    public partial class TelaPagarConta : Window
    {
        private PagarContaBLL pagarContaBLL = new PagarContaBLL();
        private MySqlCommand command = null;
        private Conexao conexao = new Conexao();

        public TelaPagarConta()
        {
            InitializeComponent();
            ListarContaPagar();
            lblData.Content = DateTime.Today;
            SomaTotaMes();
        }

        //limpa os valores após uma ação
        private void Limpar()
        {
            txtCodigoPagarConta.Clear();
            txtDescricao.Clear();
            txtValor.Clear();
        }

        private bool SalvarPagarConta(PagarConta pagarConta)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtDescricao.Text == "" || txtValor.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    pagarConta.Data = Convert.ToDateTime(lblData.Content);
                    pagarConta.Descricao = txtDescricao.Text;
                    pagarConta.Valor = Convert.ToDouble(txtValor.Text);
                    
                    pagarContaBLL.SalvarContaPagar(pagarConta);

                    MessageBox.Show("Cadastro feito com sucesso");
                    
                    ListarContaPagar();
                    SomaTotaMes();
                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private bool EditarPagarConta(PagarConta pagarConta)
        {

            try
            {
                //caso os campos estiverem vazios
                if ( txtDescricao.Text == "" || txtValor.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    pagarConta.CodPagarConta = Convert.ToInt64(txtCodigoPagarConta.Text);
                    pagarConta.Data = Convert.ToDateTime(lblData.Content);
                    pagarConta.Descricao = txtDescricao.Text;
                    pagarConta.Valor = Convert.ToDouble(txtValor.Text);
                    


                    MessageBoxResult alteracao = MessageBox.Show("Deseja realmete salvar as alterações ?", "Editar", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (alteracao == MessageBoxResult.Yes)
                    {

                        pagarContaBLL.EditarContaPagar(pagarConta);

                        MessageBox.Show("Edição feito com sucesso");
                        Limpar();
                        ListarContaPagar();
                        SomaTotaMes();
                    }
                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private bool ExcluirPagarConta()
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtDescricao.Text == "" || txtValor.Text == "" )
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    long codPagarConta = Convert.ToInt64(txtCodigoPagarConta.Text);

                    MessageBoxResult exclusao = MessageBox.Show("Deseja realmete Excluir essa conta ?", "Excluir", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (exclusao == MessageBoxResult.Yes)
                    {
                        pagarContaBLL.ExcluirContaPagar(codPagarConta);

                        MessageBox.Show("Exclusão feito com sucesso");
                        Limpar();
                        ListarContaPagar();
                        SomaTotaMes();
                    }
                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        //listar
        private void ListarContaPagar()
        {
            try
            {
                dgPagarConta.ItemsSource = pagarContaBLL.ListarContaPagar().DefaultView;//obtém todos os dados
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        public void SomaTotaMes()
        {
            try
            {
                conexao.Conectar();
                
                command = new MySqlCommand("select sum(valor) from pagarconta;", conexao.conexao);
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    txtTotalMes.Text = dr["sum(valor)"].ToString();
                }
                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        private void BtnSalvarContaPagar_Click(object sender, RoutedEventArgs e)
        {
            PagarConta pagarConta = new PagarConta();
            SalvarPagarConta(pagarConta);
        }

        private void dgPagarConta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                var rowView = dgPagarConta.SelectedItems[0] as DataRowView;
                txtCodigoPagarConta.Text = rowView["codPagarConta"].ToString();
                txtDescricao.Text = rowView["descricao"].ToString();
                txtValor.Text = rowView["valor"].ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            PagarConta pagarConta = new PagarConta();
            EditarPagarConta(pagarConta);
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ExcluirPagarConta();
        }

        
        private void TxtTotalMes_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}

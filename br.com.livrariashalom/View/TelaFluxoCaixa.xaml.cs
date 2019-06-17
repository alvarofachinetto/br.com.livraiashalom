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
    /// Lógica interna para TelaFuxoCaixa.xaml
    /// </summary>
    public partial class TelaFluxoCaixa : Window
    {
        private FluxoCaixaBLL fluxoCaixaBLL = new FluxoCaixaBLL();
        private Conexao conexao = new Conexao();
        private MySqlCommand command = null;

        public TelaFluxoCaixa()
        {
            InitializeComponent();
            lblDia.Content = DateTime.Today.ToString("dd/MM/yyyy");
            SomaEntrada();
            SomaSaida();
            CalcularSaldo();
            ListarFluxo();
        }

        public void Limpar()
        {
            txtCodigo.Clear();
            txtObservaoes.Clear();
            txtPagamentoDia.Clear();
            txtPrevisto.Clear();
            txtRecebimentoDia.Clear();
            txtSaldo.Clear();
        }

        public void SomaEntrada()
        {
            try
            {
                conexao.Conectar();
                command = new MySqlCommand("select sum(valor) from receberconta where data = curdate()", conexao.conexao);
                
                MySqlDataReader dr = command.ExecuteReader();

                dr.Read();
                if (dr.HasRows)
                {
                    txtRecebimentoDia.Text = dr["sum(valor)"].ToString(); 
                }
                dr.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
               conexao.Desconectar();
            }
        }

        public void SomaSaida()
        {
            try
            {
                conexao.Conectar();

                command = new MySqlCommand("select sum(valor) from pagarconta where data = curdate()", conexao.conexao);
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtPagamentoDia.Text = dr["sum(valor)"].ToString();
                }
                dr.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void CalcularSaldo()
        {
            double totalEntrada = Convert.ToDouble(txtRecebimentoDia.Text);
            double totalSaida = Convert.ToDouble(txtPagamentoDia.Text);
            double saldo = totalEntrada - totalSaida;

            txtSaldo.Text = Convert.ToString(saldo);
        }

        private bool SalvarFluxo(FluxoCaixa fluxoCaixa)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtObservaoes.Text == "" || txtPrevisto.Text == "" )
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    fluxoCaixa.Dia = DateTime.Now;
                    fluxoCaixa.Observacoes = txtObservaoes.Text;
                    fluxoCaixa.ValorEntrada = Convert.ToDouble(txtRecebimentoDia.Text);
                    fluxoCaixa.ValorSaida = Convert.ToDouble(txtPagamentoDia.Text);
                    fluxoCaixa.ValorPrevisto = Convert.ToDouble(txtPrevisto.Text);
                    fluxoCaixa.Saldo = Convert.ToDouble(txtSaldo.Text);

                    fluxoCaixaBLL.SalvarFluxo(fluxoCaixa);

                    MessageBox.Show("Dia feito com sucesso");
                    Limpar();
                    ListarFluxo();
                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        public void ListarFluxo()
        {
            try
            {
                dgFluxoCaixa.ItemsSource = fluxoCaixaBLL.ListarFluxo().DefaultView;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            FluxoCaixa fluxoCaixa = new FluxoCaixa();
            SalvarFluxo(fluxoCaixa);
        }

        private void TxtEntrada_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        
        private void dgFluxoCaixa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtTotalPagar_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }
    }
}

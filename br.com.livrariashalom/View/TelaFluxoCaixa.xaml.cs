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
            lblDia.Content = DateTime.Today;
            SomaEntrada();
            SomaSaida();
        }

        public void SomaEntrada()
        {
            try
            {
                conexao.Conectar();
                
                command = new MySqlCommand("select sum(r.valor) from receberconta r where data  = @data",conexao.conexao);
                command.Parameters.AddWithValue("@data", lblDia.Content);

                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    txtTotalReceber.Text = dr["sum(r.valor)"].ToString(); 
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

                command = new MySqlCommand("select  sum(p.valor) from pagarconta p where data  = @data", conexao.conexao);
                command.Parameters.AddWithValue("@data", lblDia.Content);

                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    txtTotalPagar.Text = dr["sum(p.valor)"].ToString();
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
                    fluxoCaixa.ValorEntrada = Convert.ToDouble(txtTotalReceber.Text);
                    fluxoCaixa.ValorSaida = Convert.ToDouble(txtTotalPagar.Text);
                    fluxoCaixa.ValorPrevisto = Convert.ToDouble(txtPrevisto.Text);
                    fluxoCaixa.Saldo = Convert.ToInt32(txtSaldo.Text);

                    fluxoCaixaBLL.SalvarFluxo(fluxoCaixa);

                    MessageBox.Show("Cadastro feito com sucesso");


                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

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
            double totalEntrada = int.Parse(txtTotalReceber.Text);
            double totalSaida = int.Parse(txtTotalPagar.Text);
            double saldo = totalEntrada - totalEntrada;

            txtSaldo.Text = String.Format("{0:C}", saldo);

        }
    }
}

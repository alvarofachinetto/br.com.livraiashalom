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
        private FluxoCaixa fluxoCaixa = new FluxoCaixa();
        private Conexao conexao = new Conexao();
        private MySqlCommand command = null;

        public TelaFluxoCaixa()
        {
            InitializeComponent();
            lblDia.Content = DateTime.Today;
            SomaDoDia();
        }

        public void SomaDoDia()
        {
            try
            {
                conexao.Conectar();
                
                command = new MySqlCommand("select sum(r.valor), sum(p.valor) from receberconta r join pagarconta p where data  = @data",conexao.conexao);
                command.Parameters.AddWithValue("@data", lblDia.Content);

                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    txtTotalReceber.Text = dr["sum(r.valor)"].ToString();
                    txtTotalPagar.Text = dr["sum(p.valor)"].ToString();
                }
                
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

        //private bool SalvarFluxo(FluxoCaixa fluxoCaixa)
        //{

        //    try
        //    {
        //        //caso os campos estiverem vazios
        //        if (txtObservaoes.Text == "" || txtEntrada.Text == "" || txtSaida.Text == "" || txtPagarConta.Text == "" || txtReceberConta.Text == "" || txtPrevisto.Text == "" || txtSaldo.Text == "")
        //        {
        //            MessageBox.Show("Campos com * são obrigatórios o preenchimento");
        //        }
        //        else
        //        {
        //            fluxoCaixa.Dia = DateTime.Now;
        //            fluxoCaixa.Observacoes = txtObservaoes.Text;
        //            fluxoCaixa.ValorEntrada = Convert.ToDouble(txtEntrada.Text);
        //            fluxoCaixa.ValorSaida = Convert.ToDouble(txtSaida.Text);
        //            fluxoCaixa.ValorPrevisto = Convert.ToDouble(txtPrevisto.Text);
        //            fluxoCaixa.PagarConta.CodPagarConta = Convert.ToInt32(txtPagarConta.Text);
        //            fluxoCaixa.ReceberConta.CodReceberConta = Convert.ToInt32(txtReceberConta.Text);

        //            fluxoCaixaBLL.SalvarFluxo(fluxoCaixa);

        //            MessageBox.Show("Cadastro feito com sucesso");


        //            return true;
        //        }

        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show("Erro: " + error);
        //    }
        //    return false;

        //}

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //SalvarFluxo(fluxoCaixa);
        }

        private void TxtEntrada_TextChanged(object sender, TextChangedEventArgs e)
        {
            //double entrada = Convert.ToDouble(txtEntrada.Text);
            //double saida = Convert.ToDouble(txtSaida.Text);
            //double saldo = entrada - saida;

            //txtSaldo.Text = String.Format("{0:C}", saldo);

        }
        
        private void dgFluxoCaixa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtTotalPagar_TextChanged(object sender, TextChangedEventArgs e)
        {
            int totalEntrada = int.Parse(txtTotalReceber.Text);
            int totalSaida = int.Parse(txtTotalPagar.Text);
            int saldo = totalEntrada - totalEntrada;
            txtSaldo.Text = Convert.ToString(saldo);
        }
    }
}

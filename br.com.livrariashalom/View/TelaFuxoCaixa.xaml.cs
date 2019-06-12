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
    /// Lógica interna para TelaFuxoCaixa.xaml
    /// </summary>
    public partial class TelaFuxoCaixa : Window
    {
        private FluxoCaixaBLL fluxoCaixaBLL = new FluxoCaixaBLL();
        private FluxoCaixa fluxoCaixa = new FluxoCaixa();


        public TelaFuxoCaixa()
        {
            InitializeComponent();
            lblDia.Content = DateTime.Today;
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
        
        //botao pré-calculado
        private void TxtSaldo_TextChanged(object sender, TextChangedEventArgs e)
        {

           
        }
    }
}

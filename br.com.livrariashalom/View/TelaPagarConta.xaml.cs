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
    /// Lógica interna para TelaPagarConta.xaml
    /// </summary>
    public partial class TelaPagarConta : Window
    {
        private PagarContaBLL pagarContaBLL = new PagarContaBLL();

        public TelaPagarConta()
        {
            InitializeComponent();
        }

        private bool SalvarPagarConta(PagarConta pagarConta)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtData.Text == "" || txtDescricao.Text == "" || txtValor.Text == "" || cmbStatus.Text == "" || txtDataVencimento.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    pagarConta.Data = Convert.ToDateTime(txtData.Text);
                    pagarConta.Descricao = txtDescricao.Text;
                    pagarConta.Valor = Convert.ToDouble(txtValor.Text);
                    pagarConta.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
                    pagarConta.Status = cmbStatus.Text;

                    pagarContaBLL.SalvarContaPagar(pagarConta);

                    MessageBox.Show("Cadastro feito com sucesso");
                    MessageBox.Show("Código do Conta: " + pagarConta.CodPagarConta);

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private void BtnSalvarContaPagar_Click(object sender, RoutedEventArgs e)
        {
            PagarConta pagarConta = new PagarConta();
            SalvarPagarConta(pagarConta);
        }
    }
}

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
    /// Lógica interna para TelaReceberConta.xaml
    /// </summary>
    public partial class TelaReceberConta : Window
    {
        private ReceberContaBLL receberContaBLL = new ReceberContaBLL();

        public TelaReceberConta()
        {
            InitializeComponent();
        }

        private bool SalvarReceberConta(ReceberConta receberConta)
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
                    receberConta.Data = Convert.ToDateTime(txtData.Text);
                    receberConta.Descricao = txtDescricao.Text;
                    receberConta.Valor = Convert.ToDouble(txtValor.Text);
                    receberConta.Status = cmbStatus.Text;

                    receberContaBLL.SalvarReceberConta(receberConta);

                    MessageBox.Show("Cadastro feito com sucesso");
                    MessageBox.Show("Código do Conta: " + receberConta.CodReceberConta);

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
            ReceberConta receberConta = new ReceberConta();
            SalvarReceberConta(receberConta);
        }
    }
}

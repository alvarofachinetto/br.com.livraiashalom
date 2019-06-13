using br.com.livrariashalom.BLL;
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
    /// Lógica interna para TelaHistoricoRecebimento.xaml
    /// </summary>
    public partial class TelaHistoricoRecebimento : Window
    {
        private ReceberContaBLL receberContaBLL = new ReceberContaBLL();

        public TelaHistoricoRecebimento()
        {
            InitializeComponent();
            ListarHistoricoReceberConta();
        }

        public void ListarHistoricoReceberConta()
        {
            try
            {
                dgHistoricoPagarConta.ItemsSource = receberContaBLL.ListarReceberConta().DefaultView;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void PesquisarPagarConta()
        {
            try
            {
                if (datePickerData.SelectedDate != null)
                {
                    DateTime data = (DateTime)datePickerData.SelectedDate;
                    dgHistoricoPagarConta.ItemsSource = receberContaBLL.PesquisarContaReceber(data).DefaultView;
                }
                else
                {
                    MessageBox.Show("Preencha o campo da data");
                }

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            PesquisarPagarConta();
        }
    }
}

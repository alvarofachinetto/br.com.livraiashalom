using br.com.livrariashalom.BLL;
using br.com.livrariashalom.DAO;
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
    /// Lógica interna para TelaHistoricoPagarConta.xaml
    /// </summary>
    public partial class TelaHistoricoPagarConta : Window
    {
        private PagarContaBLL contaBLL = new PagarContaBLL();

        public TelaHistoricoPagarConta()
        {
            InitializeComponent();
            ListarHistoricoPagarConta();
        }

        public void ListarHistoricoPagarConta()
        {
            try
            {
                dgHistoricoPagarConta.ItemsSource = contaBLL.ListarHistoricoPagarConta().DefaultView;
            }catch(Exception erro)
            {
                throw erro;
            }
        }

        public void PesquisarPagarConta()
        {
            try
            {
                DateTime data = (DateTime) datePickerData.SelectedDate;
                dgHistoricoPagarConta.ItemsSource = contaBLL.PesquisarContaPagar(data).DefaultView;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void dgHistoricoPagarConta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            PesquisarPagarConta();
        }
    }
}

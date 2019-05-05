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
    /// Lógica interna para TelaItemVenda.xaml
    /// </summary>
    public partial class TelaItemVenda : Window
    {
        private ItemVendaBLL itemVendaBLL;

        public TelaItemVenda()
        {
            InitializeComponent();
        }

       

        private void BtnPesquisarLivro_Click(object sender, RoutedEventArgs e)
        {
            TelaEstoque telaEstoque = new TelaEstoque();
            telaEstoque.Show();
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TxtCodProduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}

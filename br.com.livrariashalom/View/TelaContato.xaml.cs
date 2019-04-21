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
    /// Lógica interna para TelaContato.xaml
    /// </summary>
    public partial class TelaContato : Window
    {
       

        public TelaContato()
        {
            InitializeComponent();
        }

       

        private void BtnCadastroContato_Click(object sender, RoutedEventArgs e)
        {
            
            CadastrarContato(contato);
        }

        private void txtFornecedor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

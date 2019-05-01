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

        private bool SalvarItem(ItemVenda itemVenda)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtQtd.Text == "" || txtSubTotal.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    itemVenda.Quantidade = Convert.ToInt32(txtQtd.Text);
                    itemVenda.Livro.CodLivro = Convert.ToInt32(txtCodLivro.Text);
                    itemVenda.Produto.CodProduto = Convert.ToInt32(txtCodProduto.Text);
                    itemVenda.SubTotal = Convert.ToDouble(txtSubTotal.Text);

                    itemVendaBLL = new ItemVendaBLL();
                    itemVendaBLL.SalvarItem(itemVenda);

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private void BtnPesquisarLivro_Click(object sender, RoutedEventArgs e)
        {
            TelaEstoque telaEstoque = new TelaEstoque();
            telaEstoque.Show();
        }
    }
}

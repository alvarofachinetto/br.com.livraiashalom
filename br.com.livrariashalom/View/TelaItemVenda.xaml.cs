using br.com.livrariashalom.BLL;
using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;
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
    /// Lógica interna para TelaItemVenda.xaml
    /// </summary>
    public partial class TelaItemVenda : Window
    {
        private ItemVendaBLL  itemVendaBLL = new ItemVendaBLL();
                    
       

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
                    itemVenda.Venda.CodVenda = Convert.ToInt32(txtCodVenda.Text);

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

        private void TxtCodLivro_TextChanged(object sender, TextChangedEventArgs e)
        {
            //caso livro esteja vazio, automaticamente ele recebe um valor null
            if (txtCodLivro.Text == "")
            {
                ItemVenda itemVenda = new ItemVenda();
                itemVenda.Livro.CodLivro = Convert.ToInt32(null);
            }
        }

        private void TxtCodProduto_TextChanged(object sender, TextChangedEventArgs e)
        {
            //caso produto esteja vazio, automaticamente ele recebe um valor null
            if (txtCodProduto.Text == "")
            {
                ItemVenda itemVenda = new ItemVenda();
                itemVenda.Produto.CodProduto = Convert.ToInt32(null);
            }
        }

        private void TxtSubTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            LivroDAO livroDAO = new LivroDAO();
            System.Console.Write(livroDAO.CalcularSubTotal());

        }

        //salvara e listara os itens na tabela
        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ItemVenda itemVenda = new ItemVenda();
                SalvarItem(itemVenda);

                TelaVendas telaVendas = new TelaVendas();

                var rowView = telaVendas.dgItem.SelectedItems[0] as DataRowView;
                txtCodLivro.Text = rowView["codLivro"].ToString();

                txtCodProduto.Text = rowView["codProduto"].ToString();
                txtQtd.Text = rowView["quantidade"].ToString();
                txtSubTotal.Text = rowView["subtotal"].ToString();
                
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }
    }
}

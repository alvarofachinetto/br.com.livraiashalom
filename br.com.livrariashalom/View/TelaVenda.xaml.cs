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
    /// Lógica interna para TelaVendas.xaml
    /// </summary>
    public partial class TelaVendas : Window
    {
        private VendaBLL vendaBLL;
        private ItemVendaBLL itemVendaBLL; 

        public TelaVendas()
        {
            InitializeComponent();
            
        }

       
        //recebe os valores para salvar
        private bool SalvarVenda(Venda venda)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtCliente.Text == "" || txtData.Text == "" || txtFrete.Text == "" || cmbFormaPag.Text == "" || txtCodPrazo.Text == "" || txtCodVendedor.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    venda.NomeCliente = txtCliente.Text;
                    venda.Telefone = txtTelefone.Text;
                    venda.LoginFuncionario.CodFuncionario = Convert.ToInt32(txtCodVendedor.Text);
                    venda.DataVenda = Convert.ToDateTime(txtData.Text);
                    venda.FormaPagamento = cmbFormaPag.Text;
                    venda.Frete = Convert.ToDouble(txtFrete.Text);
                    venda.CodPrazo.CodCondPagamento = Convert.ToInt16(txtCodPrazo.Text);
                    venda.Observacao = txtObservacao.Text;


                    vendaBLL = new VendaBLL();
                    vendaBLL.SalvarVenda(venda);
                    
                    MessageBox.Show("Cadastro feito com sucesso");
                    MessageBox.Show("Código do venda: " + venda.CodVenda);

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }
        //salvar itens
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
                    itemVenda.SubTotal = Convert.ToDouble(txtSubTotal.Text);
                    itemVenda.Venda.CodVenda = Convert.ToInt64(txtCodVenda.Text);

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

        //lista todos os livros
        private void ListarItem(ItemVenda itemVenda)
        {
            try
            {
                itemVenda.Venda.CodVenda = Convert.ToInt64(txtCodVenda.Text);
                dgItem.ItemsSource = itemVendaBLL.ListarItem(itemVenda).DefaultView;//obtém todos os dados
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }
        //baixa no estoque de livro
        private void VendaLivro(ItemVenda itemVenda)
        {
            try
            {
                itemVenda.Venda.CodVenda = Convert.ToInt64(txtCodVenda.Text);
                itemVenda.Quantidade = Convert.ToInt32(txtQtd.Text);

                itemVendaBLL = new ItemVendaBLL();
                itemVendaBLL.VendaLivro(itemVenda);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        private void BtnPesquisarLivro_Click(object sender, RoutedEventArgs e)
        {
            TelaEstoque telaEstoque = new TelaEstoque();
            telaEstoque.Show();
        }

        private void TxtCodLivro_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            ItemVenda itemVenda = new ItemVenda();
            SalvarItem(itemVenda);
            ListarItem(itemVenda);
        }

        private void TxtTotal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
        //abre o estoque de produtos
        private void BtnPesquisarProduto_Click(object sender, RoutedEventArgs e)
        {
            TelaEstoque telaEstoque = new TelaEstoque();
            telaEstoque.Show();
            telaEstoque.tabControlEstoque.SelectedIndex = 1;

        }

        private void CmbFormaPag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbFormaPag.SelectedValue.ToString();
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult finalizar = MessageBox.Show("Deseja finalizar a venda ?", "Finalizar", MessageBoxButton.YesNo);

            if (finalizar == MessageBoxResult.Yes)
            {
                ItemVenda itemVenda = new ItemVenda();
                VendaLivro(itemVenda);
                MessageBox.Show("Venda finalizada com sucesso !");
            }
            else if (finalizar == MessageBoxResult.No)
            {
                //metodo excluir
            }
        }

        private void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            Venda venda = new Venda();
            SalvarVenda(venda);
        }

        private void TxtSubTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double preco = Convert.ToDouble(txtPreco.Text);
                double quantidade = Convert.ToDouble(txtQtd.Text);

                double subTotal = preco * quantidade;

                txtSubTotal.Text = Convert.ToString(subTotal);

                System.Console.WriteLine(txtSubTotal);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro);
            }
        }
    }
}

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
    /// Lógica interna para TelaVendas.xaml
    /// </summary>
    public partial class TelaVendas : Window
    {
        private VendaBLL vendaBLL;
        private ItemVendaBLL itemVendaBLL;
        private Conexao conexao = new Conexao();
        private MySqlCommand command = null;

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
                if (txtCodLivro.Text == "" || txtQtd.Text == "" || txtSubTotal.Text == "" || txtCodVenda.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    itemVenda.Livro.CodLivro = Convert.ToInt32(txtCodLivro.Text);
                    itemVenda.Quantidade = Convert.ToInt32(txtQtd.Text);
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
        public List<ItemVenda> VendaLivro()
        {
            try
            {
                ItemVenda itemVenda = new ItemVenda();

                conexao.Conectar();


                command = new MySqlCommand("select Livro_codLivro, quantidade from itemvenda where Venda_codVenda = @codVenda;", conexao.conexao);
                command.Parameters.AddWithValue("@codVenda", txtCodVenda.Text);

                MySqlDataReader dataReader = command.ExecuteReader();
                List<ItemVenda> listaItens = new List<ItemVenda>();

                
                //lê os itens e adiciona numa lista
                while (dataReader.Read())
                {
                    itemVenda.Livro.CodLivro = Convert.ToInt64(dataReader["Livro_codLivro"]);
                    itemVenda.Quantidade = Convert.ToInt32( dataReader["quantidade"]);
                    
                    listaItens.Add(itemVenda);
                }
                dataReader.Close();

                int qtdEstoque = Convert.ToInt32(txtQtdEstoque.Text);

                if (qtdEstoque < itemVenda.Quantidade)
                {
                    MessageBox.Show("Quantidade não suficiente", "Alerta");
                }
                else
                {
                    foreach (ItemVenda itensVenda in listaItens)
                    {
                        command = new MySqlCommand("UPDATE livro SET quantidade = quantidade - @quantidade WHERE codLivro = @codLivro", conexao.conexao);
                        //command.Parameters.AddWithValue("@quantidade", );
                        command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
                        command.ExecuteNonQuery();
                    }

                }

                return listaItens;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
               conexao.Desconectar();
            }
        }

        
        //busca o código da venda
        public void BuscarCodVenda()
        {
            try
            {
                
                conexao.Conectar();


                MySqlCommand command = new MySqlCommand("select codVenda from venda where codVenda = last_insert_id(codVenda)", conexao.conexao);

                MySqlDataReader dr = command.ExecuteReader();

                String codVenda = "";
                while (dr.Read())
                {
                    codVenda = dr["codVenda"].ToString();
                }

                txtCodVenda.Text = codVenda;
                dr.Close();

            }
            catch (Exception erro)
            {
                throw erro;
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

              
        private void CmbFormaPag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbFormaPag.SelectedValue.ToString();
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult finalizar = MessageBox.Show("Deseja finalizar a venda ?", "Finalizar", MessageBoxButton.YesNo);

            //se sim finaliza a venda e da a baxia no estoque
            if (finalizar == MessageBoxResult.Yes)
            {
                ItemVenda itemVenda = new ItemVenda();
                VendaLivro();
                MessageBox.Show("Venda finalizada com sucesso !");
            }
            //caso não a venda é totalmente excluida
            else if (finalizar == MessageBoxResult.No)
            {
                long codVenda = Convert.ToInt64(txtCodVenda.Text);
                vendaBLL.DeletarVenda(codVenda);
            }
        }

        private void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            Venda venda = new Venda();
            SalvarVenda(venda);
            
            tabVenda.SelectedIndex = 1;
        }

        private void txtCodLivro_Copy_KeyUp(object sender, KeyEventArgs e)
        {
            LivroDAO livroDAO = new LivroDAO();
            
            livroDAO.BuscaLivro();
            this.Close();

        }

        private void TxtPreco_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TxtQtd_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double preco = Convert.ToDouble(txtPreco.Text);
                double quantidade = Convert.ToDouble(txtQtd.Text);

                double subTotal = preco * quantidade;

                txtSubTotal.Text = Convert.ToString(subTotal);


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro);
            }
        }

        private void TxtCodVenda_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void GridItem_Initialized(object sender, EventArgs e)
        {
            
        }

        private void DgItem_KeyUp(object sender, KeyEventArgs e)
        {
            //for(int i=0; i<dgItem.m)
            //var rowView = dgItem.SelectedItems[0] as DataRowView;
            //txtTotal.Text = rowView["valorUnit"].ToString();

        }

    }
}

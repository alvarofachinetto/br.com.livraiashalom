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
        private Conexao conexao = new Conexao();
        private MySqlCommand command = null;
        private double Total;

        public TelaVendas()
        {
            InitializeComponent();
            // BuscarCodVenda();

        }

        private void Limpar()
        {
            txtCodLivro.Clear();
            txtSubTotal.Clear();
            txtPreco.Clear();
            txtQtdEstoque.Clear();
            txtQtd.Clear();

        }

        //public void GerarColunas()
        //{
        //    dgItem.Columns.Count.Equals()

        //    dgItem.Columns[0].Header = "CodItem";
        //    dgItem.Columns[1].Header = "preco";
        //    dgItem.Columns[2].Header = "quantidade";
        //    dgItem.Columns[3].Header = "subTotal";
        //    dgItem.Columns[4].Header = "Venda";
        //}




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
        //salvar item
        //public void SalvarItemVenda(ItemVenda itemVenda)
        //{
        //    try
        //    {
        //        conexao.Conectar();

        //        //recebe os valores da textbox
        //        itemVenda.Estoque.CodRegistro = Convert.ToInt32(txtCodLivro.Text);
        //        itemVenda.Quantidade = Convert.ToInt32(txtQtd.Text);
        //        itemVenda.SubTotal = Convert.ToDouble(txtSubTotal.Text);

        //        command = new MySqlCommand("insert into itemvenda (Estoque_codRegistro, quantidade, subTotal) value (@codRegistro, @quantidade, @subTotal)",conexao.conexao); //conexao está referente as infos do banco

        //        command.Parameters.AddWithValue("@codRegistro", itemVenda.Estoque.CodRegistro);
        //        command.Parameters.AddWithValue("@quantidade", itemVenda.Quantidade);
        //        command.Parameters.AddWithValue("@subTotal", itemVenda.SubTotal);

        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception error)
        //    {
        //        throw error;
        //    }
        //}

        //adiciona os itens no datgrid
        public void AdicionarItemTabela()
        {
            int codItem = Convert.ToInt32(txtCodLivro.Text);
            int qtd = Convert.ToInt32(txtQtd.Text);
            double subTotal = Convert.ToDouble(txtSubTotal.Text);
            double preco = Convert.ToDouble(txtPreco.Text);
            int info = Convert.ToInt32(txtInfos.Text);

            if (int.Parse(txtQtdEstoque.Text) < codItem)
            {
                MessageBox.Show("Quantidade não suficiente no estoque");
            }
            else
            {
                //var items = new []
                //{
                //    new{Item = codItem, Preco = preco, Qunatidade = qtd, SubTotal = subTotal, Info = info}
                //};


                //dgItem.ItemsSource = items;
                //dgItem.Items.Add(codItem, qtd);
                //dgItem.Items.Add(new ItemVenda { CodItemVenda = codItem, Preco = preco, Quantidade = qtd, SubTotal = subTotal, Info = info });
                Total += subTotal;

                txtTotal.Text = Convert.ToString(Total);

            }

        }

        //coloca os valores buscados na textbox
        public void BuscarEstoque()
        {
            try
            {
                conexao.Conectar();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select e.* , l.preco from estoque e inner join livro l", conexao.conexao);


                MySqlDataReader dr = command.ExecuteReader();

                dr.Read();
                if (dr.HasRows)
                {
                    txtPreco.Text = dr["preco"].ToString();
                    txtQtdEstoque.Text = dr["qtd"].ToString();
                    txtQtd.Focus();
                }
                else
                {
                    MessageBox.Show("Livro não cadastrado");
                }

            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        //baixa no estoque de livro
        public void VendaLivro()
        {
            try
            {
                //    ItemVenda itemVenda = new ItemVenda();

                //    conexao.Conectar();

                //    command = new MySqlCommand("select Estoque_codRegistro, quantidade from itemvenda where Venda_codVenda = @codVenda;", conexao.conexao);
                //    command.Parameters.AddWithValue("@codVenda", txtCodVenda.Text);

                //    MySqlDataReader dataReader = command.ExecuteReader();
                //    List<ItemVenda> listaItens = new List<ItemVenda>();

                //    while (dataReader.Read())
                //    {
                //        itemVenda.Estoque.CodRegistro = Convert.ToInt32(dataReader["Estoque_codRegistro"]);
                //        itemVenda.Estoque.QtdSaida = Convert.ToInt32(dataReader["quantidade"]);

                //        listaItens.Add(itemVenda);
                //    }
                //    dataReader.Close();

                for (int i = 0; i < dgItem.Items.Count; i++)
                {
                    DataRowView dataRow = (DataRowView)dgItem.SelectedItems;

                    int saida = Convert.ToInt32(dataRow.Row[1].ToString());

                    int codRegistro = Convert.ToInt32(dataRow.Row[3].ToString());
                    int qtdEstoque = Convert.ToInt32(txtQtdEstoque.Text);

                    if (qtdEstoque < saida)
                    {
                        MessageBox.Show("Quantidade não suficiente", "Alerta");
                    }
                    else
                    {
                        command = new MySqlCommand("update estoque set qtdSaida =  qtdSaida + @qtdSaida , qtd = qtd - @qtdSaida where codRegistro = @codRegistro ", conexao.conexao);
                        command.Parameters.AddWithValue("@qtdSaida", saida);
                        command.Parameters.AddWithValue("@codRegistro", codRegistro);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro" + erro);
            }
            finally
            {
                conexao.Desconectar();
            }
        }



        ////busca o código da venda
        //public void BuscarCodVenda()
        //{
        //    try
        //    {

        //        conexao.Conectar();

        //        MySqlCommand command = new MySqlCommand("select codVenda from venda where codVenda = last_insert_id(codVenda)", conexao.conexao);

        //        MySqlDataReader dr = command.ExecuteReader();

        //        String codVenda = "";
        //        while (dr.Read())
        //        {
        //            codVenda = dr["codVenda"].ToString();
        //        }

        //        txtInfos.Text = codVenda;
        //        dr.Close();

        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }
        //}



        //private void BtnPesquisarLivro_Click(object sender, RoutedEventArgs e)
        //{
        //    TelaEstoque telaEstoque = new TelaEstoque();
        //    telaEstoque.Show();
        //}

        private void TxtCodLivro_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            AdicionarItemTabela();

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
                VendaLivro(); //realiza baixa
                MessageBox.Show("Venda finalizada com sucesso !");
                Limpar();//limpa os campos
                tabVenda.SelectedIndex = 0; //volta para o inicio da tela
            }
            //caso não a venda é totalmente excluida
            else if (finalizar == MessageBoxResult.No)
            {
                //long codVenda = Convert.ToInt64(txtCodVenda.Text);
                //vendaBLL.DeletarVenda(codVenda);
            }
        }

        private void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            Venda venda = new Venda();
            SalvarVenda(venda);

            tabVenda.SelectedIndex = 1;
        }

        //private void txtCodLivro_Copy_KeyUp(object sender, KeyEventArgs e)
        //{
        //    LivroDAO livroDAO = new LivroDAO();

        //    livroDAO.BuscaLivro();
        //    this.Close();

    //}

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

        private void TxtCodLivro_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            BuscarEstoque();
        }
    }
}

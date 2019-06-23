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
        private ItemVendaBLL ItemVendaBLL = new ItemVendaBLL();
        private ItemVenda itemVenda = new ItemVenda();
        private Conexao conexao = new Conexao();
        private MySqlCommand command = null;
       

        public TelaVendas()
        {
            InitializeComponent();
            lblData.Content = DateTime.Now;
            ListarLivro();
            ListarUsuario();
            ListarCondPagamento();
        }

        //limpa os campos
        private void Limpar()
        {
            txtCodLivro.Clear();
            txtSubTotal.Clear();
            txtPreco.Clear();
            txtQtdEstoque.Clear();
            txtQtd.Clear();

        }
        //deixa os campos bloqueados 
        private void BloquearCamposInformativos()
        {
            txtCliente.IsReadOnly = true;
            txtTelefone.IsReadOnly = true;
            cmbVendedor.IsReadOnly = true;
            txtObservacao.IsReadOnly = true;
            cmbFormaPag.IsReadOnly = true;
            cmbPrazo.IsReadOnly = true;
            txtFrete.IsReadOnly = true;
        }
        //desbloqueia os campos dos itens
        private void DesbloquearCamposItens()
        {
            cmbLivro.IsReadOnly = false;
            txtQtd.IsReadOnly = false;
            txtTotal.IsReadOnly = false;
        }
        //recebe os valores para salvar
        private bool SalvarVenda()
        {
            Venda venda = new Venda();
            try
            {
                //caso os campos estiverem vazios
                if (txtCliente.Text == "" || txtFrete.Text == "" || cmbFormaPag.Text == "" || txtCodPrazo.Text == "" || txtCodVendedor.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {

                    venda.NomeCliente = txtCliente.Text;
                    venda.Telefone = txtTelefone.Text;
                    venda.LoginFuncionario.CodFuncionario = Convert.ToInt32(txtCodVendedor.Text);
                    venda.DataVenda = Convert.ToDateTime(lblData.Content);
                    venda.FormaPagamento = cmbFormaPag.Text;
                    venda.Frete = Convert.ToDouble(txtFrete.Text);
                    venda.Prazo.CodCondPagamento = Convert.ToInt64(txtCodPrazo.Text);
                    venda.Observacao = txtObservacao.Text;

                    MessageBoxResult salvar = MessageBox.Show("Deseja salvar as informações ?", "Salvar", MessageBoxButton.YesNo);
                    if (salvar == MessageBoxResult.Yes)
                    {
                        vendaBLL = new VendaBLL();
                        vendaBLL.SalvarVenda(venda);
                        BloquearCamposInformativos();
                        DesbloquearCamposItens();
                        return true;
                    }

                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }
        //pre calcula o subtotal dos itens 
        public void CalcularSaldo()
        {
            int quantidade = Convert.ToInt32(txtQtd.Text);
            double preco = Convert.ToDouble(txtPreco.Text);
            //caso esteja nulo
            if (txtQtd.Text == "")
            {
                quantidade = 0;
            }
            double saldo = preco * quantidade;

            txtSubTotal.Text = Convert.ToString(saldo);
            

        }
        //busca todos os livros
        public void ListarLivro()
        {
            try
            {
                conexao.Conectar();

                command = new MySqlCommand("select titulo from livro", conexao.conexao);
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string titulo = dr["titulo"].ToString();
                    cmbLivro.Items.Add(titulo);
                }

                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //coloca os valores buscados na textbox
        public void BuscarPorInfos()
        {
            try
            {
                string titulo = (string)cmbLivro.SelectedValue;
                //coloca o cod na textbox
                command = new MySqlCommand("select codLivro, qtd, preco from livro where titulo = @titulo", conexao.conexao);
                command.Parameters.AddWithValue("@titulo", titulo);


                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtCodLivro.Text = dr["codLivro"].ToString();
                    txtQtdEstoque.Text = dr["qtd"].ToString();
                    txtPreco.Text = dr["preco"].ToString();
                }
                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        //busca todos os usuarios
        public void ListarUsuario()
        {
            try
            {
                conexao.Conectar();

                command = new MySqlCommand("select usuario from loginfuncionario", conexao.conexao);
                MySqlDataReader dr = command.ExecuteReader();
                
                while(dr.Read())
                {
                    string usuario = dr["usuario"].ToString();
                    cmbVendedor.Items.Add(usuario);
                }

                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        //busca pelo codigo do vendedor
        public void BuscarCodVendedor()
        {
            try
            {
                string vendedor = (string)cmbVendedor.SelectedValue;
                //coloca o cod na textbox
                command = new MySqlCommand("select codUsuario from loginfuncionario where usuario = @usuario", conexao.conexao);
                command.Parameters.AddWithValue("@usuario", vendedor);


                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtCodVendedor.Text = dr["codUsuario"].ToString();
                }
                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        //busca pela condicao de pagamento
        public void ListarCondPagamento()
        {
            try
            {
                conexao.Conectar();

                command = new MySqlCommand("select condicao_pagamento from prazo", conexao.conexao);
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    string usuario = dr["condicao_pagamento"].ToString();
                    cmbPrazo.Items.Add(usuario);
                }

                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        //busca pelo codigo do condicao de pagamento
        public void BuscarCodCondPagamento()
        {
            try
            {
                string condPagamento = (string) cmbPrazo.SelectedValue;
                //coloca o cod na textbox
                command = new MySqlCommand("select codCondicao_pagamento from prazo where condicao_pagamento = @pagamento", conexao.conexao);
                command.Parameters.AddWithValue("@pagamento", condPagamento);


                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtCodPrazo.Text = dr["codCondicao_pagamento"].ToString();
                }
                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void SalvarItem()
        {
            try
            {
                //caso os campos estiverem vazios
                if (txtCodLivro.Text == "" || txtQtd.Text == "" || txtCodLivro.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    itemVenda.Quantidade = Convert.ToInt32(txtQtd.Text);
                    itemVenda.SubTotal = Convert.ToDouble(txtSubTotal.Text);
                    itemVenda.Livro.CodLivro = Convert.ToInt64(txtCodLivro.Text);
                    ItemVendaBLL.SalvarItem(itemVenda);
                    ListarItem();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        public void ListarItem()
        {
            try
            {
                dgItem.ItemsSource = ItemVendaBLL.ListarItem().DefaultView;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public void ExcluirItem()
        {
            try
            {
                if (txtCodItem.Text == "" || txtQtd.Text == "" || txtCodLivro.Text == "")
                {
                    MessageBox.Show("Selecione um item");
                }
                else
                {
                    itemVenda.CodItemVenda = Convert.ToInt64(txtCodItem.Text);
                    itemVenda.Quantidade = Convert.ToInt32(txtQtd.Text);
                    itemVenda.Livro.CodLivro = Convert.ToInt64(txtCodLivro.Text);
                    ItemVendaBLL.ExcluirItem(itemVenda);
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            SalvarItem();
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
                
                MessageBox.Show("Venda finalizada com sucesso !");
                Limpar();//limpa os campos
                
            }
            //caso não a venda é totalmente excluida
            else if (finalizar == MessageBoxResult.No)
            {
                //long codVenda = Convert.ToInt64(txtCodVenda.Text);
                //vendaBLL.DeletarVenda(codVenda);
            }
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


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuscarPorInfos();
        }

        private void CmbVendedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuscarCodVendedor();
        }

        private void CmbPrazo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuscarCodCondPagamento();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Venda venda = new Venda();
            SalvarVenda();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExcluirItem();
        }
    }
}

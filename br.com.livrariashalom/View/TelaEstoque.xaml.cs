using br.com.livrariashalom.BLL;
using br.com.livrariashalom.Model;
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
    /// Lógica interna para TelaEstoque.xaml
    /// </summary>
    public partial class TelaEstoque : Window
    {
        private LivroBLL livroBLL = new LivroBLL();
        private EstoqueBLL estoqueBLL = new EstoqueBLL();

        public TelaEstoque()
        {
            InitializeComponent();
            ListarLivro();//lista todos os livros quando inicia

        }

        //lista todos os livros
        private void ListarLivro()
        {
            try
            {
                dgLivro.ItemsSource = estoqueBLL.ListarLivroEsoque().DefaultView;//obtém todos os dados
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        private bool PesquisarLivro()
        {
            try
            {
                if (txtPesquisar.Text == "")
                {
                    MessageBox.Show("Preencha o campo ", "Alerta");
                    return false;
                }
                else
                {
                    String titulo = txtPesquisar.Text;

                    livroBLL = new LivroBLL();
                    livroBLL.PesquisarTituloLivro(titulo);
                    return true;
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        //salva o livro no estoque
        public bool SalvarLivroEstoque(Estoque estoque)
        {
            try
            {
                //caso os campos estiverem vazios
                if (txtCodLivro.Text == "" || txtDescricao.Text == "" || txtEntrada.Text == "" || txtQtdEstoque.Text == "" || txtSaida.Text == "" || txtAlerta.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    estoque.CodLivro.CodLivro = Convert.ToInt64(txtCodLivro.Text);
                    estoque.Livro = txtDescricao.Text;
                    estoque.QtdAlerta = Convert.ToInt32(txtAlerta.Text);
                    estoque.QtdEntrada = Convert.ToInt32(txtEntrada.Text);
                    estoque.QtdSaida = Convert.ToInt32(txtSaida.Text);
                    estoque.QtdEstoque = Convert.ToInt32(txtQtdEstoque.Text);

                    estoqueBLL.SalvarLivroEsoque(estoque);
                    MessageBox.Show("Cadastro feito com sucesso");

                    return true;
                }
                return false;
            }catch (Exception erro)
            {
                throw erro;
            }
        }
    

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            PesquisarLivro();
        }

        private void dgLivro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        //busca as infos e coloca nas text box
        private void dgLivro_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TelaVendas telaVendas = new TelaVendas();

                var rowView = dgLivro.SelectedItems[0] as DataRowView;
                telaVendas.txtCodLivro.Text = rowView["codRegistro"].ToString();
                telaVendas.txtPreco.Text = rowView["preco"].ToString();
                telaVendas.txtQtdEstoque.Text = rowView["qtd"].ToString();

                telaVendas.tabVenda.SelectedIndex = 1;
                telaVendas.BuscarCodVenda();
                telaVendas.Show();

                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        private void BtnVenda_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Estoque estoque = new Estoque();
            SalvarLivroEstoque(estoque);
        }
    }
}

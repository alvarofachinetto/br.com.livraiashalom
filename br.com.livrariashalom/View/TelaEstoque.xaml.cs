using br.com.livrariashalom.BLL;
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
                dgLivro.ItemsSource = livroBLL.ListarLivro().DefaultView;//obtém todos os dados
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

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            PesquisarLivro();
        }

        /*private void TabItemEstoqueLivro_MouseDoubleClick(object sender, MouseButtonEventArgs e)
         {
             try
             {
                 TelaLivro telaLivro = new TelaLivro();

                 var rowView = dgLivro.SelectedItems[0] as DataRowView;
                 telaLivro.txtCodLivro.Text = rowView["Código"].ToString();

                 telaLivro.txtTitulo.Text = rowView["Titulo"].ToString();
                 telaLivro.txtAutor.Text = rowView["Autor"].ToString();
                 telaLivro.txtEditora.Text = rowView["Editora"].ToString();
                 telaLivro.cmbFase.Text = rowView["Fase"].ToString();
                 telaLivro.txtQtd.Text = rowView["Quantidade"].ToString();
                 telaLivro.txtCategoria.Text = rowView["Categoria"].ToString();
                 telaLivro.txtValor.Text = rowView["Preço"].ToString();
                 telaLivro.txtAlerta.Text = rowView["Alerta"].ToString();
                 telaLivro.txtFornecedorLivro.Text = rowView["Fornecedor"].ToString();
                 telaLivro.txtDescricao.Text = rowView["Descrição"].ToString();
             }
             catch(Exception error)
             {
                 MessageBox.Show("Erro: " + error);
             }

         }*/
    }
}

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
                telaVendas.txtCodLivro.Text = rowView["codLivro"].ToString();
                telaVendas.txtPreco.Text = rowView["valorUnit"].ToString();
                telaVendas.txtQtdEstoque.Text = rowView["quantidade"].ToString();

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
    }
}

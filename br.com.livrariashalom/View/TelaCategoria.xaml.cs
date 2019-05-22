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
    /// Lógica interna para TelaCategoriaLivro.xaml
    /// </summary>
    public partial class TelaCategoria : Window
    {
        CategoriaBLL categoriaBLL = new CategoriaBLL();

        public TelaCategoria()
        {
            InitializeComponent();
        }

        private bool SalvarCategoriaLivro(Categoria categoria)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtCategoria.Text == "")
                {
                    MessageBox.Show("É obrigatório preencher a categoria");
                }
                else
                {
                    categoria.CategoriaGeral = txtCategoria.Text;
                    categoriaBLL.SalvarCategoria(categoria);

                    MessageBox.Show("Cadastro feito com sucesso");
                    MessageBox.Show("Código do fornecedor: " + categoria.CodCategoria);

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private bool EditarCategoriaLivro(Categoria categoria)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtCategoria.Text == "")
                {
                    MessageBox.Show("É obrigatório preencher a categoria");
                }
                else
                {
                    categoria.CategoriaGeral = txtCategoria.Text;

                    MessageBoxResult alteracao = MessageBox.Show("Deseja realmete salvar as alterações ?", "Editar", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (alteracao == MessageBoxResult.Yes)
                    {
                        categoriaBLL.EditarCategoria(categoria);
                        MessageBox.Show("Edição feita com sucesso");
                        
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

        private bool ExcluirCategoriaLivro(Categoria categoria)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtCodCategoriaLivro.Text == "")
                {
                    MessageBox.Show("É obrigatório preencher a o campo do código");
                }
                else
                {
                    categoria.CategoriaGeral = txtCategoria.Text;

                    MessageBoxResult excluir = MessageBox.Show("Deseja realmete excluir a categoria ?", "Excluir", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (excluir == MessageBoxResult.Yes)
                    {
                        categoriaBLL.ExcluirCategoria(categoria);
                        MessageBox.Show("Exclusão feita com sucesso");

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

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoriaLivro = new Categoria();
            SalvarCategoriaLivro(categoriaLivro);
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = new Categoria();
            EditarCategoriaLivro(categoria);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = new Categoria();
            ExcluirCategoriaLivro(categoria);
        }
    }
}

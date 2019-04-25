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

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoriaLivro = new Categoria();
            SalvarCategoriaLivro(categoriaLivro);
        }
    }
}

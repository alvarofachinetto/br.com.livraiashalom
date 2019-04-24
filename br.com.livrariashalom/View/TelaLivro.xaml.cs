using br.com.livrariashalom.BLL;
using br.com.livrariashalom.MODEL;
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
    /// Lógica interna para TelaLivro.xaml
    /// </summary>
    public partial class TelaLivro : Window
    {
        private LivroBLL livroBLL = new LivroBLL();

        public TelaLivro()
        {
            InitializeComponent();
        }

        private bool SalvarLivro(Livro livro)
        {
            try
            {
                //caso os campos estiverem vazios
                if (txtTitulo.Text == "" || txtAutor.Text == "" || txtEditora.Text == "" || cmbFase.Text == "" || txtQtd.Text == "" || txtCategoria.Text == "" || txtValor.Text == "" || txtAlerta.Text == "" || txtFornecedorLivro.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    livro.Titulo = txtTitulo.Text;
                    livro.Autor = txtAutor.Text;
                    livro.Editora = txtTitulo.Text;
                    livro.Fase = cmbFase.Text;
                    livro.Qtd = Convert.ToInt32(txtQtd.Text);
                    livro.Categoria = txtCategoria.Text;
                    livro.ValorUnit = Convert.ToDouble(txtValor.Text);
                    livro.QtdAlerta = Convert.ToInt32(txtQtd.Text);
                    livro.Descricao = txtDescricao.Text;
                    livro.Fornecedor.CodFornecedor = Convert.ToInt64(txtFornecedorLivro.Text);

                    livroBLL.SalvarLivro(livro);

                    MessageBox.Show("Cadastro feito com sucesso");
                    MessageBox.Show("Código do fornecedor: " + livro.CodLivro);

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
            Livro livro = new Livro();
            SalvarLivro(livro);
        }

        private void CmbFase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String valor = cmbFase.SelectedValue.ToString();
        }
    }
}

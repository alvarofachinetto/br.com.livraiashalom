using br.com.livrariashalom.BLL;
using br.com.livrariashalom.MODEL;
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
    /// Lógica interna para TelaLivro.xaml
    /// </summary>
    public partial class TelaLivro : Window
    {
        private LivroBLL livroBLL;

        public TelaLivro()
        {
            InitializeComponent();
        }

        //limpa os valores após uma ação
        private void Limpar()
        {
            txtCodLivro.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEditora.Clear();
            cmbFase.SelectedIndex = 0;
            txtQtd.Clear();
            txtCategoria.Clear();
            txtValor.Clear();
            txtAlerta.Clear();
            txtFornecedorLivro.Clear();
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
                    livro.CodCategoria.CodCategoria = Convert.ToInt32(txtCategoria.Text);
                    livro.ValorUnit = Convert.ToDouble(txtValor.Text);
                    livro.QtdAlerta = Convert.ToInt32(txtQtd.Text);
                    livro.Descricao = txtDescricao.Text;
                    livro.Fornecedor.CodFornecedor = Convert.ToInt64(txtFornecedorLivro.Text);

                    livroBLL = new LivroBLL();
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

        //editar livro
        private bool EditarLivro(Livro livro)
        {
            try
            {
                //caso os campos estiverem vazios
                if (txtCodLivro.Text == "" || txtTitulo.Text == "" || txtAutor.Text == "" || txtEditora.Text == "" || cmbFase.Text == "" || txtQtd.Text == "" || txtCategoria.Text == "" || txtValor.Text == "" || txtAlerta.Text == "" || txtFornecedorLivro.Text == "")
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
                    livro.CodCategoria.CodCategoria = Convert.ToInt32(txtCategoria.Text);
                    livro.ValorUnit = Convert.ToDouble(txtValor.Text);
                    livro.QtdAlerta = Convert.ToInt32(txtQtd.Text);
                    livro.Descricao = txtDescricao.Text;
                    livro.Fornecedor.CodFornecedor = Convert.ToInt64(txtFornecedorLivro.Text);
                    livro.CodLivro = Convert.ToInt64(txtCodLivro.Text);


                    MessageBoxResult alteracao = MessageBox.Show("Deseja realmete salvar as alterações ?", "Editar", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (alteracao == MessageBoxResult.Yes)
                    {
                        livroBLL = new LivroBLL();
                        livroBLL.EditarLivro(livro);
                        MessageBox.Show("Edição feita com sucesso");
                         
                        Limpar();

                        return true;
                    }

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;
        }

        //pesquisar Livro por código arrumar
        private bool PesquisarLivro()
        {
            try
            {
                if (txtCodLivro.Text == "")
                {
                    MessageBox.Show("Preencha o campo do código", "Alerta");
                    return false;
                }
                else
                {
                    int codLivro = Convert.ToInt32(txtCodLivro.Text);

                    livroBLL = new LivroBLL();
                    livroBLL.PesquisarLivro(codLivro);
                    return true;
                }
            }
            catch(Exception erro)
            {
                throw erro;
            }   
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

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            Livro livro = new Livro();
            EditarLivro(livro);
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            PesquisarLivro();
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            telaPrincipal.Show();
            this.Close();
        }

        private void BtnEstoque_Click(object sender, RoutedEventArgs e)
        {
            TelaEstoque telaEstoque = new TelaEstoque();
            telaEstoque.Show();
        }
    }
}

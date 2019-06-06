using br.com.livrariashalom.BLL;
using br.com.livrariashalom.DAO;
using br.com.livrariashalom.MODEL;
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
    /// Lógica interna para TelaLivro.xaml
    /// </summary>
    public partial class TelaLivro : Window
    {
        private Conexao conexao = new Conexao();
        private MySqlCommand command = null;
        private LivroBLL livroBLL = new LivroBLL();

        public TelaLivro()
        {
            InitializeComponent();
            ListarFornecedor();
            ListarLivros();
            ListarCategoria();
        }

        //limpa os valores após uma ação
        private void Limpar()
        {
            txtCodLivro.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEditora.Clear();
            txtQtd.Clear();
            cmbFase.SelectedIndex = 0;
            txtCategoria.Clear();
            txtValor.Clear();
            txtFornecedorLivro.Clear();
            txtDescricao.Clear();
            txtAlerta.Clear();
        }

        private bool SalvarLivro(Livro livro)
        {
            try
            {
                //caso os campos estiverem vazios
                if (txtTitulo.Text == "" || txtAutor.Text == "" || txtEditora.Text == "" || cmbFase.Text == "" ||  txtCategoria.Text == "" || txtValor.Text == "" ||  txtFornecedorLivro.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    
                    livro.Titulo = txtTitulo.Text;
                    livro.Autor = txtAutor.Text;
                    livro.Editora = txtTitulo.Text;
                    livro.Fase = cmbFase.Text;
                    livro.QtdAlerta = Convert.ToInt32(txtAlerta.Text);
                    livro.CodCategoria.CodCategoria = Convert.ToInt64(txtCategoria.Text);
                    livro.ValorUnit = Convert.ToDouble(txtValor.Text);
                    livro.Qtd = Convert.ToInt32(txtQtd.Text);
                    livro.Descricao = txtDescricao.Text;
                    livro.Fornecedor.CodFornecedor = Convert.ToInt64(txtFornecedorLivro.Text);

                    livroBLL = new LivroBLL();
                    livroBLL.SalvarLivro(livro);

                    MessageBox.Show("Cadastro feito com sucesso");
                    Limpar();
                    ListarLivros();
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
                if (txtCodLivro.Text == "" || txtTitulo.Text == "" || txtAutor.Text == "" || txtEditora.Text == "" || cmbFase.Text == "" || txtCategoria.Text == "" || txtValor.Text == ""  || txtFornecedorLivro.Text == "")
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
                    livro.QtdAlerta = Convert.ToInt32(txtAlerta.Text);
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

                        ListarLivros();
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

        private bool ExcluirLivro()
        {
            try
            {
                long codLivro = Convert.ToInt64(txtCodLivro.Text);

                MessageBoxResult alteracao = MessageBox.Show("Deseja realmete excluir o livro ?", "Excluir", MessageBoxButton.YesNo);

                //caso o usuário realmente queira fazer a alteração
                if (alteracao == MessageBoxResult.Yes)
                {
                    livroBLL.ExcluirLivro(codLivro);
                    ListarLivros();
                    MessageBox.Show("Edição feita com sucesso");

                    ListarLivros();
                    Limpar();
                    return true;
                }

                return true;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //lista os fornecedores e categoria
        public void ListarFornecedor()
        {
            try
            {
                conexao.Conectar();

                command = new MySqlCommand("select f.nome_razao from fornecedor f", conexao.conexao);
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string razao = dr["nome_razao"].ToString();
                    cmbFornecedor.Items.Add(razao);            
                }

                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //busca o código do fornecedor e categoria
        public void BuscarPorCodigo()
        {
            try
            {
                string razao = (string)cmbFornecedor.SelectedValue;
                //coloca o cod na textbox
                command = new MySqlCommand("select f.codFornecedor from fornecedor f where nome_razao = @razao", conexao.conexao);
                command.Parameters.AddWithValue("@razao", razao);

                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtFornecedorLivro.Text = dr["codFornecedor"].ToString();
                }
                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        //lista as categorias na combobox
        public void ListarCategoria()
        {
            try
            {
                conexao.Conectar();

                command = new MySqlCommand("select c.categoriaGeral from categoria c", conexao.conexao);
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string categoria = dr["categoriaGeral"].ToString();
                    cmbCategoria.Items.Add(categoria);
                }

                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        //listar livros no datagrid
        public void ListarLivros()
        {
            try
            {
                dgLivro.ItemsSource = livroBLL.ListarLivro().DefaultView;
            }catch(Exception erro)
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

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            telaPrincipal.Show();
            this.Close();
        }

        private void cmbFornecedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuscarPorCodigo();
        }
        //leva a info da tabela para textbox
        private void DgLivro_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var rowView = dgLivro.SelectedItems[0] as DataRowView;
                txtCodLivro.Text = rowView["codLivro"].ToString();

                txtTitulo.Text = rowView["titulo"].ToString();
                txtAutor.Text = rowView["autor"].ToString();
                txtEditora.Text = rowView["editora"].ToString();
                cmbFase.Text = rowView["fase"].ToString();
                txtCategoria.Text = rowView["Categoria_codCategoria"].ToString();
                txtValor.Text = rowView["preco"].ToString();
                txtQtd.Text = rowView["qtd"].ToString();
                txtDescricao.Text = rowView["descricao"].ToString();
                txtAlerta.Text = rowView["qtdAlerta"].ToString();
                txtFornecedorLivro.Text = rowView["Fornecedor_codFornecedor"].ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        private void CmbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string categoria = (string)cmbCategoria.SelectedValue;
                //coloca o cod na textbox
                command = new MySqlCommand("select c.codCategoria from categoria c where categoriaGeral = @categoria", conexao.conexao);
                command.Parameters.AddWithValue("@categoria", categoria);

                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtCategoria.Text = dr["codCategoria"].ToString();
                }
                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            Limpar();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ExcluirLivro();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            Livro livro = new Livro();
            EditarLivro(livro);
        }
    }
}

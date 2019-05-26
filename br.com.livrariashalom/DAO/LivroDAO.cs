using br.com.livrariashalom.MODEL;
using br.com.livrariashalom.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace br.com.livrariashalom.DAO
{
    public class LivroDAO : Conexao
    {
        MySqlCommand command = null;

        public void SalvarLivro(Livro livro)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into livro (titulo, autor, editora, fase, quantidade, qtdAlerta, Categoria_codCategoria, valorUnit, descricao, Fornecedor_codFornecedor) values " +
                "(@titulo, @autor, @editora, @fase, @quantidade, @qtdAlerta, @codCategoria, @valorUnit, @descricao, @codFornecedor)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@titulo", livro.Titulo);
                command.Parameters.AddWithValue("@autor", livro.Autor);
                command.Parameters.AddWithValue("@editora", livro.Editora);
                command.Parameters.AddWithValue("@fase", livro.Fase);
                command.Parameters.AddWithValue("@quantidade", livro.Qtd);
                command.Parameters.AddWithValue("@qtdAlerta", livro.QtdAlerta);
                command.Parameters.AddWithValue("@codCategoria", livro.CodCategoria.CodCategoria);
                command.Parameters.AddWithValue("@valorUnit", livro.ValorUnit);
                command.Parameters.AddWithValue("@descricao", livro.Descricao);
                command.Parameters.AddWithValue("@codFornecedor", livro.Fornecedor.CodFornecedor);

                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                Desconectar();
            }
        }

        //Metodo listar 
        public DataTable ListarLivro()
        {
            try
            {

                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from livro", conexao);
                
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);//adiciona ou atualiza as linhas 

                return dt;

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                Desconectar();
            }
        }

        public DataTable BuscaLivro()
        {
            try
            {

                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                TelaVendas telaVendas = new TelaVendas();
                command = new MySqlCommand("select * from livro where titulo like '" +  telaVendas.txtCodLivro.Text+"%'", conexao);

                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);//adiciona ou atualiza as linhas 

                TelaEstoque telaEstoque = new TelaEstoque();
                telaEstoque.Show();
                return dt;

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                Desconectar();
            }
        }



        //pesquisar livro
        public void PesquisarLivro(int codLivro)
        {
            try
            {
                Conectar();
                
                command = new MySqlCommand("select * from livro where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@codLivro", codLivro);

                MySqlDataReader dr = command.ExecuteReader();

                while(dr.Read())
                {
                    if (dr.HasRows != true)
                    {
                        MessageBox.Show("Produto não existe no estoque");
                    }
                    else
                    {
                        TelaLivro telaLivro = new TelaLivro();

                        telaLivro.txtTitulo.Text = dr.GetString(1);
                        telaLivro.txtAutor.Text = dr.GetString(2);
                        telaLivro.txtEditora.Text = dr.GetString(3);
                        telaLivro.cmbFase.Text = dr.GetString(4);
                        telaLivro.txtQtd.Text = dr.GetString(5);
                        telaLivro.txtCategoria.Text = dr.GetString(6);
                        telaLivro.txtValor.Text = dr.GetString(7);
                        telaLivro.txtAlerta.Text = dr.GetString(8);
                        telaLivro.txtFornecedorLivro.Text = dr.GetString(9);
                        telaLivro.txtDescricao.Text = dr.GetString(10);
                    }
                }
                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                Desconectar();
            }
        }

        public DataTable PesquisarTituloLivro(String titulo)
        {
            try
            {
                Conectar();

                TelaEstoque telaEstoque = new TelaEstoque();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                command = new MySqlCommand("select * from livro where titulo like @titulo", conexao);
                command.Parameters.AddWithValue("@titulo", titulo + "%");

                command.CommandType = CommandType.Text;
                
                da.SelectCommand = command;
                da.Fill(dt);

                //dgLivro.ItemsSource = dt.AsDataView();

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                Desconectar();
            }
        }

        //metodo editar
        public void EditarLivro(Livro livro)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update livro set titulo = @titulo, autor = @autor, editora = @editora, " +
                "fase = @fase, quantidade = @quantidade, categoriaLivro = @categoriaLivro, valorUnit = @valorUnit, " +
                "descricao = @descricao ,Fornecedor_codFornecedor = @codFornecedor where codLivro = @codLivro", conexao);

                command.Parameters.AddWithValue("@titulo", livro.Titulo);
                command.Parameters.AddWithValue("@autor", livro.Autor);
                command.Parameters.AddWithValue("@editora", livro.Editora);
                command.Parameters.AddWithValue("@fase", livro.Fase);
                command.Parameters.AddWithValue("@quantidade", livro.Qtd);
                command.Parameters.AddWithValue("@categoriaLivro", livro.CodCategoria.CodCategoria);
                command.Parameters.AddWithValue("@valorUnit", livro.ValorUnit);
                command.Parameters.AddWithValue("@descricao", livro.Descricao);
                command.Parameters.AddWithValue("@codFornecedor", livro.Fornecedor.CodFornecedor);
                command.Parameters.AddWithValue("@codLivro", livro.CodLivro);

                command.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                Desconectar();
            }
        }

        //Metodo excluir
        public void ExcluirLivro(Livro livro)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from livro where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@codLivro", livro.CodLivro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                Desconectar();
            }
        }



    }
}

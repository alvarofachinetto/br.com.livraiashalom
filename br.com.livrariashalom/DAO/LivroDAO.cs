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

                command = new MySqlCommand("insert into livro (titulo, autor, editora, fase, quantidade, qtdAlerta, categoriaLivro, valorUnit, descricao, Fornecedor_codFornecedor) values " +
                "(@titulo, @autor, @editora, @fase, @quantidade, @qtdAlerta, @categoriaLivro, @valorUnit, @descricao, @codFornecedor)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@titulo", livro.Titulo);
                command.Parameters.AddWithValue("@autor", livro.Autor);
                command.Parameters.AddWithValue("@editora", livro.Editora);
                command.Parameters.AddWithValue("@fase", livro.Fase);
                command.Parameters.AddWithValue("@quantidade", livro.Qtd);
                command.Parameters.AddWithValue("@qtdAlerta", livro.QtdAlerta);
                command.Parameters.AddWithValue("@categoriaLivro", livro.Categoria);
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

        //pesquisar livro
        public void PesquisarLivro(Livro livro)
        {
            try
            {

                Conectar();
                
                command = new MySqlCommand("select titulo, autor, editora, fase, quantidade, categoriaLivro, valorUnit, qtdAlerta, Fornecedor_codFornecedor, descricao from livro where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@codLivro", livro.CodLivro);

                MySqlDataReader dr = command.ExecuteReader();

                if(dr.HasRows != true)
                {
                    MessageBox.Show("Produto não existe no estoque");
                }
                else { 
                
                    dr.Read();

                    TelaLivro telaLivro = new TelaLivro();
                    
                    telaLivro.txtTitulo.Text = Convert.ToString(dr["titulo"]);
                    telaLivro.txtAutor.Text = Convert.ToString(dr["autor"]);
                    telaLivro.txtEditora.Text = Convert.ToString(dr["editora"]);
                    telaLivro.cmbFase.Text = Convert.ToString(dr["fase"]);
                    telaLivro.txtQtd.Text = Convert.ToString(dr["quantidade"]);
                    telaLivro.txtCategoria.Text = Convert.ToString(dr["categoriaLivro"]);//mudar
                    telaLivro.txtValor.Text = Convert.ToString(dr["valorUnit"]);
                    telaLivro.txtAlerta.Text = Convert.ToString(dr["qtdAlerta"]);
                    telaLivro.txtFornecedorLivro.Text = Convert.ToString(dr["Fornecedor_codFornecedor"]);
                    telaLivro.txtDescricao.Text = Convert.ToString(dr["descricao"]);
                }
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
                command.Parameters.AddWithValue("@categoriaLivro", livro.Categoria);
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
        public void ExcluirFornecedor(Livro livro)
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

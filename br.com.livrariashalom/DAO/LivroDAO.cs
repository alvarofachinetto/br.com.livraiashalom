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

                command = new MySqlCommand("insert into livro (titulo, autor, editora, fase, qtd, Categoria_codCategoria, preco, qtdAlerta, descricao, Fornecedor_codFornecedor) values " +
                "(@titulo, @autor, @editora, @fase, @qtd, @codCategoria, @preco, @qtdAlerta, @descricao, @codFornecedor)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@titulo", livro.Titulo);
                command.Parameters.AddWithValue("@autor", livro.Autor);
                command.Parameters.AddWithValue("@editora", livro.Editora);
                command.Parameters.AddWithValue("@fase", livro.Fase);
                command.Parameters.AddWithValue("@codCategoria", livro.CodCategoria.CodCategoria);
                command.Parameters.AddWithValue("@preco", livro.ValorUnit);
                command.Parameters.AddWithValue("@qtd", livro.Qtd);
                command.Parameters.AddWithValue("@qtdAlerta", livro.QtdAlerta);
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

                command = new MySqlCommand("select * from livro order by codLivro", conexao);
                
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


        //metodo editar
        public void EditarLivro(Livro livro)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update livro set titulo = @titulo, autor = @autor, editora = @editora, fase = @fase, qtd = @quantidade, Categoria_codCategoria = @categoriaLivro, preco = @valorUnit, qtdAlerta = @alerta, descricao = @descricao ,Fornecedor_codFornecedor = @codFornecedor where codLivro = @codLivro", conexao);

                command.Parameters.AddWithValue("@titulo", livro.Titulo);
                command.Parameters.AddWithValue("@autor", livro.Autor);
                command.Parameters.AddWithValue("@editora", livro.Editora);
                command.Parameters.AddWithValue("@fase", livro.Fase);
                command.Parameters.AddWithValue("@quantidade", livro.Qtd);
                command.Parameters.AddWithValue("@categoriaLivro", livro.CodCategoria.CodCategoria);
                command.Parameters.AddWithValue("@valorUnit", livro.ValorUnit);
                command.Parameters.AddWithValue("@alerta", livro.QtdAlerta);
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
        public void ExcluirLivro(long codLivro)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from livro where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@codLivro", codLivro);
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

using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.DAO
{
    public class EstoqueDAO : Conexao
    {
        MySqlCommand command = null;

        public void SalvarLivro(Estoque estoque)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into estoque (livro, qtd, qtdAlerta, Livro_codLivro) values " +
                "(@livro, @qtd, @qtdAlerta, @codLivro)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@livro", estoque.Livro);
                command.Parameters.AddWithValue("@qtd", estoque.QtdEstoque);
                command.Parameters.AddWithValue("@qtdAlerta", estoque.QtdAlerta);
                command.Parameters.AddWithValue("@codLivro", estoque.CodLivro.CodLivro);
                
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
        public DataTable ListarEstoque()
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select e.* , l.preco from estoque e inner join livro l", conexao);

                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);//adiciona ou atualiza as linhas 

                return dt;

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

    }
}

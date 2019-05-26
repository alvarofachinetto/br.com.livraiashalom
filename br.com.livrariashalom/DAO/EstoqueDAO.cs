using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

    }
}

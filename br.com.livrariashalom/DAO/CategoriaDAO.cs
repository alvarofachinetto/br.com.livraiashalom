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
    public class CategoriaDAO : Conexao
    {
        MySqlCommand command = null;

        public void SalvarCategoria (Categoria categoria)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into categoria (categoriaGeral) value (@categoriaGeral)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis de classe login 
                command.Parameters.AddWithValue("@categoriaGeral", categoria.CategoriaGeral);
                
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
        /* public DataTable Listar()
         {
             try
             {

                 conectar();
                 DataTable dt = new DataTable();//tabela de dados
                 MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                 command = new MySqlCommand("select * from categoria", conexao);

                 dataAdapter.SelectCommand = command;
                 dataAdapter.Fill(dt);//atualiza as linhas 

                 return dt;

             }
             catch (Exception erro)
             {
                 throw erro;
             }
             finally
             {
                 desconectar();
             }
         }*/

        public void EditarCategoria(Categoria categoria)
        {
            try
            {

                Conectar();

                command = new MySqlCommand("update from categoria set categoriaGeral = @categoria where codCategoria = @codCategoria", conexao);
                command.Parameters.AddWithValue("@categoria", categoria.CategoriaGeral);
                command.Parameters.AddWithValue("@codCategoria", categoria.CodCategoria);

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

        public void ExcluirCategoria(Categoria categoria)
        {
            try
            {

                Conectar();

                command = new MySqlCommand("delete from categoria where codCategoria = @codCategoria", conexao);
                command.Parameters.AddWithValue("@codCategoria", categoria.CodCategoria);

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
    }
}

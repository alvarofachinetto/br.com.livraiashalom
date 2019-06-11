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
    public class PagarContaDAO : Conexao
    {
        MySqlCommand command = null;

        public void SalvarPagarConta(PagarConta pagarConta)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into pagarconta (data, descricao, valor) values (@data, @descricao, @valor)", conexao);
                command.Parameters.AddWithValue("@data", pagarConta.Data);
                command.Parameters.AddWithValue("@descricao", pagarConta.Descricao);
                command.Parameters.AddWithValue("@valor", pagarConta.Valor);
                
                command.ExecuteNonQuery();

            }catch(Exception error)
            {
                throw error;
            }
            finally
            {
                Desconectar();
            }
            
        }

        public DataTable ListarContaPagar()
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from pagarconta order by data",conexao);
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dt);

                return dt;

            }catch(Exception error)
            {
                throw error;
            }
            finally{
                Desconectar();
            }
        }
        //editar registro
        public void EditarContaPagar(PagarConta pagarConta)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update pagarconta set data = @data, descricao = @descricao, valor = @valor, where codPagarConta = @codPagarConta", conexao);
                command.Parameters.AddWithValue("@data", pagarConta.Data);
                command.Parameters.AddWithValue("@descricao", pagarConta.Descricao);
                command.Parameters.AddWithValue("@valor", pagarConta.Valor);
                command.Parameters.AddWithValue("@codPagarConta", pagarConta.CodPagarConta);

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
        public void ExcluirContaPagar(long codPagarConta)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from pagarconta where codPagarConta = @codPagarConta", conexao);
                command.Parameters.AddWithValue("@codPagarConta", codPagarConta);
           
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

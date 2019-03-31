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
                conectar();

                command = new MySqlCommand("insert into pagarconta (data, descricao, valor, datavencimento, status) values (@data, @descricao, @valor, @dataVencimento, @status)");
                command.Parameters.AddWithValue("@data", pagarConta.Data);
                command.Parameters.AddWithValue("@dscricao", pagarConta.Descricao);
                command.Parameters.AddWithValue("@valor", pagarConta.Valor);
                command.Parameters.AddWithValue("@dataVencimento", pagarConta.DataVencimento);
                command.Parameters.AddWithValue("@status", pagarConta.Status);

                command.ExecuteNonQuery();

            }catch(Exception error)
            {
                throw error;
            }
            finally
            {
                desconectar();
            }
            
        }

        public DataTable ListarContaPagar()
        {
            try
            {
                conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from pagarconta");
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dt);

                return dt;

            }catch(Exception error)
            {
                throw error;
            }
            finally{
                desconectar();
            }
        }

        public void EditarContaPagar(PagarConta pagarConta)
        {
            try
            {
                conectar();

                command = new MySqlCommand("update pagarconta set data = @data, descricao = @descricao, valor = @valor, datavencimento = @dataVencimento, status = @status where codPagarConta = @codPagarConta", conexao);
                command.Parameters.AddWithValue("@data", pagarConta.Data);
                command.Parameters.AddWithValue("@descricao", pagarConta.Descricao);
                command.Parameters.AddWithValue("@valor", pagarConta.Valor);
                command.Parameters.AddWithValue("@dataVencimento", pagarConta.DataVencimento);
                command.Parameters.AddWithValue("@status", pagarConta.Status);
                command.Parameters.AddWithValue("@idPagarConta", pagarConta.CodPagarConta);

                command.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                desconectar();
            }
        }

        //Metodo excluir
        public void ExcluirFornecedor(PagarConta pagarConta)
        {
            try
            {
                conectar();

                command = new MySqlCommand("delete from pagarconta where idPagarConta = @codPagarConta", conexao);
                command.Parameters.AddWithValue("@codPagarConta", pagarConta.CodPagarConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                desconectar();
            }
        }
    }
}

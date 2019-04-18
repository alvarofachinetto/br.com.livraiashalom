using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;

namespace br.com.livrariashalom.DAO
{
    class EnderecoDAO : Conexao
    {

        MySqlCommand command = null;

        //salvar endereco
        public void SalvarEndereco(Endereco endereco)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into endereco (logradouro, numero, bairro, cidade, estado, cep, Fornecedor_codFornecedor) " +
                "values (@logradouro, @numero, @bairro, @cidade, @cep, @codFornecedor)", conexao);

                command.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                command.Parameters.AddWithValue("@numero", endereco.Numero);
                command.Parameters.AddWithValue("@bairro", endereco.Bairro);
                command.Parameters.AddWithValue("@cidade", endereco.Cidade);
                command.Parameters.AddWithValue("@estado", endereco.Estado);
                command.Parameters.AddWithValue("@cep", endereco.Cep);
                command.Parameters.AddWithValue("@codFornecedor", endereco.Fornecedor.CodFornecedor);

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

        //Metodo listar endereco
        public DataTable ListarEndereco()
        {
            try
            {

                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from endereco", conexao);

                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);

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

        //metodo editar endereco
        public void EditarEndereco(Endereco endereco)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update contato set logradouro = @logradouro, numero = @numero, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep , Fornecedor_codFornecedor = @codFornecedor where codEndereco = @codEndereco", conexao);
                command.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                command.Parameters.AddWithValue("@numero", endereco.Numero);
                command.Parameters.AddWithValue("@bairro", endereco.Bairro);
                command.Parameters.AddWithValue("@cidade", endereco.Cidade);
                command.Parameters.AddWithValue("@estado", endereco.Estado);
                command.Parameters.AddWithValue("@cep", endereco.Cep);
                command.Parameters.AddWithValue("@codFornecedor", endereco.Fornecedor.CodFornecedor);
                command.Parameters.AddWithValue("@codEndereco", endereco.CodEndereco);


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

        //Metodo excluir endereco
        public void ExcluirEndereco(Contato contato)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from endereco where codEndereco = @codEndereco", conexao);
                command.Parameters.AddWithValue("@codEndereco", contato.CodContato);
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

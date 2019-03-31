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
    public class FornecedorDAO : Conexao
    {

        MySqlCommand command = null;

        public void SalvarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                conectar();

                command = new MySqlCommand("insert into fornecedor (nome_razao, nome_fantasia, cnpj, cpf, ie, observacoes, empresa) values (@nome_razao, @nome_fantasia, @cnpj, @cpf, @ie, @observacoes, @empresa)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@nome_razao", fornecedor.NomeRazao);
                command.Parameters.AddWithValue("@nome_fantasia", fornecedor.NomeFantasia);
                command.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                command.Parameters.AddWithValue("@cpf", fornecedor.Cpf);
                command.Parameters.AddWithValue("@ie", fornecedor.Ie);
                command.Parameters.AddWithValue("@observacoes", fornecedor.Observacoes);

                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                desconectar();
            }
        }

        //Metodo listar 
        public DataTable ListarFornecedor()
        {
            try
            {

                conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from fornecedor", conexao);

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
                desconectar();
            }
        }

        //metodo editar
        public void EditarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                conectar();

                command = new MySqlCommand("update fornecedor set nome_razao = @nome_razao, nome_fantasia = @nome_fantasia, cnpj = @cnpj, cpf = @cpf, ie = @ie, observacoes = @observacoes where codFornecedor = @codFornecedor", conexao);
                command.Parameters.AddWithValue("@codFornecedor", fornecedor.CodFornecedor);
                command.Parameters.AddWithValue("@nome_razao", fornecedor.NomeRazao);
                command.Parameters.AddWithValue("@nome_fantasia", fornecedor.NomeFantasia);
                command.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                command.Parameters.AddWithValue("@cpf", fornecedor.Cpf);
                command.Parameters.AddWithValue("@ie", fornecedor.Ie);
                command.Parameters.AddWithValue("@observacoes", fornecedor.Observacoes);
                
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
        public void ExcluirFornecedor(Fornecedor fornecedor)
        {
            try
            {
                conectar();

                command = new MySqlCommand("delete from fornecedor where codFornecedor = @codFornecedor", conexao);
                command.Parameters.AddWithValue("@codFornecedor", fornecedor.CodFornecedor);
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

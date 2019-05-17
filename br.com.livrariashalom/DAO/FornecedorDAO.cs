using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace br.com.livrariashalom.DAO
{
    public class FornecedorDAO: Conexao
    {

        private MySqlCommand command = null;

        public void SalvarFornecedor(Fornecedor fornecedor)
        {
            try
            {

                Conectar();
                command = new MySqlCommand("insert into fornecedor (nome_razao, nome_fantasia, cnpjcpf, ie, observacoes, empresa) values (@nome_razao, @nome_fantasia, @cnpjcpf, @ie, @observacoes, @empresa)", conexao); //conexao está referente as infos do banco
                
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@nome_razao", fornecedor.NomeRazao);
                command.Parameters.AddWithValue("@nome_fantasia", fornecedor.NomeFantasia);
                command.Parameters.AddWithValue("@cnpjcpf", fornecedor.CnpjCpf);
                command.Parameters.AddWithValue("@ie", fornecedor.Ie);
                command.Parameters.AddWithValue("@empresa", fornecedor.Empresa);
                command.Parameters.AddWithValue("@observacoes", fornecedor.Observacoes);

                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
            finally
            {
                conexao.Close();
            }
        }

        //Metodo listar 
        public DataTable ListarFornecedor()
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from fornecedor inner join contato inner join endereco order by codFornecedor;", conexao);

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

        //metodo editar
        public void EditarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update fornecedor set nome_razao = @nome_razao, nome_fantasia = @nome_fantasia, cnpjcpf = @cnpjcpf, ie = @ie, empresa = @empresa ,observacoes = @observacoes where codFornecedor = @codFornecedor", conexao);
                command.Parameters.AddWithValue("@codFornecedor", fornecedor.CodFornecedor);
                command.Parameters.AddWithValue("@nome_razao", fornecedor.NomeRazao);
                command.Parameters.AddWithValue("@nome_fantasia", fornecedor.NomeFantasia);
                command.Parameters.AddWithValue("@cnpjcpf", fornecedor.CnpjCpf);
                command.Parameters.AddWithValue("@ie", fornecedor.Ie);
                command.Parameters.AddWithValue("@empresa", fornecedor.Empresa);
                command.Parameters.AddWithValue("@observacoes", fornecedor.Observacoes);
                
                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
            finally
            {
                Desconectar();
            }
        }

        //Metodo excluir
        public void DeletarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from fornecedor where codFornecedor = @codFornecedor", conexao);
                command.Parameters.AddWithValue("@codFornecedor", fornecedor.CodFornecedor);

                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}

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
    public class ProdutoDAO : Conexao
    {

        MySqlCommand command = null;

        public void SalvarProduto(Produto produto)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into produto (produto, valorUnit, qtd, qtdAlerta, Fornecedor_codFornecedor, Categoria_codCategoria) " +
                "values (@produto, @valorUnit, @qtd, @qtdAlerta, @codFornecedor)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@produto", produto.NomeProduto);
                command.Parameters.AddWithValue("@valorUnit", produto.ValorUnit);
                command.Parameters.AddWithValue("@qtd", produto.Qtd);
                command.Parameters.AddWithValue("@qtdAlerta", produto.QtdAlerta);
                command.Parameters.AddWithValue("@codFornecedor", produto.Fornecedor.CodFornecedor);

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
        public DataTable ListarProduto()
        {
            try
            {

                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from produto", conexao);

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
        public void EditarProduto(Produto produto)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update produto set produto = @produto, valorUnit = @valorUnit, qtd = @qtd, Fornecedor_codFornecedor = @codFornecedor where codProduto = @codProduto", conexao);
                command.Parameters.AddWithValue("@produto", produto.NomeProduto);
                command.Parameters.AddWithValue("@valorUnit", produto.ValorUnit);
                command.Parameters.AddWithValue("@qtd", produto.Qtd);
                command.Parameters.AddWithValue("@codFornecedor", produto.Fornecedor.CodFornecedor);
                command.Parameters.AddWithValue("@codLivro", produto.CodProduto);
                
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
        public void ExcluirProduto(Produto produto)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from produto where codProduto = @codProduto", conexao);
                command.Parameters.AddWithValue("@codProduto", produto.CodProduto);
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

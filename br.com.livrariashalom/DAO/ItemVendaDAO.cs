using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.DAO
{
    public class ItemVendaDAO : Conexao
    {
        MySqlCommand command = null;
        
        public void SalvarItemVenda(ItemVenda itemVenda)
        {
            try
            {
                Conectar();
                                
                command = new MySqlCommand("insert into itemvenda (Livro_codLivro, Produto_codProduto, quantidade, subTotal, Venda_codVenda) value (@codLivro, @codProduto, @quantidade, @subTotal, @codVenda)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
                command.Parameters.AddWithValue("@codProduto", itemVenda.Produto.CodProduto);
                command.Parameters.AddWithValue("@quantidade", itemVenda.Quantidade);
                command.Parameters.AddWithValue("@subTotal", itemVenda.SubTotal);
                command.Parameters.AddWithValue("@codVenda", itemVenda.Venda.CodVenda);

                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
            
        }

        //baixa no estoque de livro
        public void VendaLivro(ItemVenda itemVenda)
        {
            try
            {
                Conectar();
                command = new MySqlCommand("select quantidade from livro where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);

                MySqlDataReader dataReader = command.ExecuteReader();
                int qtdBanco = 0;

                while (dataReader.Read())
                {
                    qtdBanco = Convert.ToInt32(dataReader["quantidade"]);
                }

                dataReader.Close();

                int qtdAtual = qtdBanco - itemVenda.Quantidade;

                command = new MySqlCommand("update livro set quantidade = @quantidade where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@quantidade", qtdAtual);
                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
                command.ExecuteNonQuery();

            }catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                Desconectar();
            }
        }

        //Metodo listar 
        public DataTable ListarItemVenda(ItemVenda itemVenda)
        {
            try
            {

                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from itemvenda where codVenda = @codVenda", conexao);
                command.Parameters.AddWithValue("codVenda", itemVenda.Venda.CodVenda);

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
        public void EditarItemVenda(ItemVenda itemVenda)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update itemvenda set Livro_codLivro = @codLivro, Item_codProduto = @codProduto, quantidade = @quantidade, subTotal = @subTotal, valorTotal = @valorTotal where idProdutoVenda = @codItemVenda", conexao);

                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
                command.Parameters.AddWithValue("@codProduto", itemVenda.Produto.CodProduto);
                command.Parameters.AddWithValue("@quantidade", itemVenda.Quantidade);
                command.Parameters.AddWithValue("@subTotal", itemVenda.SubTotal);
                command.Parameters.AddWithValue("@valorTotal", itemVenda.ValorTotal);
                command.Parameters.AddWithValue("@codItemVenda", itemVenda.CodItemVenda);

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
        public void ExcluirItemVenda(ItemVenda itemVenda)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from itemvenda where idProdutoVenda = @codVenda", conexao);
                command.Parameters.AddWithValue("@codVenda", itemVenda.CodItemVenda);
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

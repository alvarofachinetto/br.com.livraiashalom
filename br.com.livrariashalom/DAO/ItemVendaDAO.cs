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
    public class ItemVendaDAO : Conexao
    {


        MySqlCommand command = null;

        public void SalvarItemVenda(ItemVenda itemVenda)
        {
            try
            {
                conectar();

                command = new MySqlCommand("insert into itemvenda (Livro_codLivro, Item_idProduto, quantidade, subTotal, valorTotal) value (@codLivro, @codProduto, @quantidade, @subTotal, @valorTotal)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
                command.Parameters.AddWithValue("@codProduto", itemVenda.Produto.CodProduto);
                command.Parameters.AddWithValue("@quantidade", itemVenda.Quantidade);
                command.Parameters.AddWithValue("@subTotal", itemVenda.SubTotal);
                command.Parameters.AddWithValue("@valorTotal", itemVenda.ValorTotal);

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
        public DataTable ListarItemVenda()
        {
            try
            {

                conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from itemvenda", conexao);

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
        public void EditarItemVenda(ItemVenda itemVenda)
        {
            try
            {
                conectar();

                command = new MySqlCommand("update itemvenda set Livro_codLivro = @codLivro, Item_idProduto = @codProduto, quantidade = @quantidade, subTotal = @subTotal, valorTotal = @valorTotal where idProdutoVenda = @codVenda", conexao);

                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
                command.Parameters.AddWithValue("@codProduto", itemVenda.Produto.CodProduto);
                command.Parameters.AddWithValue("@quantidade", itemVenda.Quantidade);
                command.Parameters.AddWithValue("@subTotal", itemVenda.SubTotal);
                command.Parameters.AddWithValue("@valorTotal", itemVenda.ValorTotal);
                command.Parameters.AddWithValue("@codVenda", itemVenda.CodProdutoVenda);

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
        public void ExcluirItemVenda(ItemVenda itemVenda)
        {
            try
            {
                conectar();

                command = new MySqlCommand("delete from itemvenda where idProdutoVenda = @codVenda", conexao);
                command.Parameters.AddWithValue("@codVenda", itemVenda.CodProdutoVenda);
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

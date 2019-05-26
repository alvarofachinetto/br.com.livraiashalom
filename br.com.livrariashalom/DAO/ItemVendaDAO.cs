using br.com.livrariashalom.Model;
using br.com.livrariashalom.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                                
                command = new MySqlCommand("insert into itemvenda (Livro_codLivro, quantidade, subTotal, Venda_codVenda) value (@codLivro, @quantidade, @subTotal, @codVenda)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis 
                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
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

        //Metodo listar 
        public DataTable ListarItemVenda(ItemVenda itemVenda)
        {
            try
            {

                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from itemvenda where Venda_codVenda = @codVenda", conexao);
                command.Parameters.AddWithValue("@codVenda", itemVenda.Venda.CodVenda);

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

                command = new MySqlCommand("update itemvenda set Livro_codLivro = @codLivro, quantidade = @quantidade, subTotal = @subTotal, valorTotal = @valorTotal where idProdutoVenda = @codItemVenda", conexao);

                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
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

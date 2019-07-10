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

        //salvar item
        public void SalvarItemVenda(ItemVenda itemVenda)
        {
            try
            {
                Conectar();

                //pegar a última info inserida
                command = new MySqlCommand("select max(codVenda) from venda;", conexao);
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    itemVenda.Venda.CodVenda = dr.GetInt64("max(codVenda)");
                }
                dr.Close();

                command = new MySqlCommand("insert into itemvenda (Livro_codLivro, quantidade, subTotal, Venda_codVenda) value (@codLivro, @quantidade, @subTotal, @codVenda)", conexao); //conexao está referente as infos do banco

                command.Parameters.AddWithValue("@quantidade", itemVenda.Quantidade);
                command.Parameters.AddWithValue("@subTotal", itemVenda.SubTotal);
                command.Parameters.AddWithValue("@codLivro", itemVenda.Livro.CodLivro);
                command.Parameters.AddWithValue("@codVenda", itemVenda.Venda.CodVenda);
                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        //diminui a qtd do estoque
        //public void DiminuirQuantidadeEstoque()
        //{
        //    try
        //    {
        //        ItemVenda itemVenda = new ItemVenda();
        //        Conectar();

        //        command = new MySqlCommand("select max(codVenda) from venda", conexao);

        //        long codVenda = 0;
        //        MySqlDataReader dr = command.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            codVenda = dr.GetInt64("max(codVenda)");
        //        }
        //        dr.Close();

        //        command = new MySqlCommand("select Livro_codLivro, quantidade from itemvenda where Venda_codVenda = @codVenda", conexao);
        //        command.Parameters.AddWithValue("@codVenda", codVenda);

        //        MySqlDataReader dataReader = command.ExecuteReader();
                
        //        while (dr.Read())
        //        {
        //            itemVenda.Livro.CodLivro = dataReader.GetInt64("Livro_codLivro");
        //            itemVenda.Quantidade = dataReader.GetInt32("quantidade"); 
        //        }
        //        dr.Close();

        //        List<ItemVenda> listaItens = new List<ItemVenda>();
        //        listaItens.Add(itemVenda);

        //        foreach (var item in listaItens)
        //        {
        //            command = new MySqlCommand("update livro set qtd = (qtd - @qtdSaida) where codLivro = @codLivro", conexao);

        //            command.Parameters.AddWithValue("@qtdSaida", qtd);
        //            command.Parameters.AddWithValue("@codLivro", codLivro);
        //            command.ExecuteNonQuery();
        //        }


        //    }
        //    catch (Exception erro)
        //    {

        //        throw erro;
        //    }
        //}
        //aumenta a qtd do estoque
        public void AumentarQuantidadeEstoque(long codLivro, int qtd)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update livro set qtd = (qtd + @qtdEntrada) where codLivro = @codLivro", conexao);

                command.Parameters.AddWithValue("@qtdEntrada", qtd);
                command.Parameters.AddWithValue("@codLivro", codLivro);
                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Metodo listar 
        public DataTable ListarItemVenda()
        {
            try
            {
                Conectar();

                command = new MySqlCommand("select max(codVenda) from venda", conexao);
                MySqlDataReader dr = command.ExecuteReader();
                long codVenda = 0;
                while (dr.Read())
                {
                    codVenda = dr.GetInt64("max(codVenda)");
                }
                dr.Close();

                ItemVenda itemVenda = new ItemVenda();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from itemvenda where Venda_codVenda = @codVenda", conexao);
                command.Parameters.AddWithValue("@codVenda", codVenda);

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

        //Metodo excluir
        public void ExcluirItemVenda(ItemVenda itemVenda)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from itemvenda where codItemVenda = @codItemVenda", conexao);
                command.Parameters.AddWithValue("@codItemVenda", itemVenda.CodItemVenda);
                command.ExecuteNonQuery();
                //devolve o livro para o estoque
                
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

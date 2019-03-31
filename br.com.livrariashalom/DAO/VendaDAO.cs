using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.DAO
{
    public class VendaDAO : Conexao
    {
        MySqlCommand command = null;

        public void SalvarVenda(Venda venda)
        {
            try
            {
                conectar();

                command = new MySqlCommand("insert into venda (nome_cliente, telefoneCli, data_venda, LoginFuncionario_codUsusario, Prazo_codCondicao_Pagamento, forma_pagamento, frete, parcelamento, ItemVenda_codItemVenda, ItemVenda_Produto_codProduto, ItemVenda_Livro_codLivro, observacoes)" +
                " values (@nomeCli, @telefoneCli, @dataVenda, @codUsuario, @condicaoPagamento, @formaPagamento, @frete, @parcelamento, @itemVenda, @itemProduto, @itemLivro, @observacoes)");

                command.Parameters.AddWithValue("@nomeCli", venda.NomeCliente);
                command.Parameters.AddWithValue("@telefoneCli", venda.Telefone);
                command.Parameters.AddWithValue("@dataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@codUsuario", venda.LoginFuncionario.CodUsuario);
                command.Parameters.AddWithValue("@condicaoPagamento", venda.CodPrazo.CodCondPagamento);
                command.Parameters.AddWithValue("@formaPagamento", venda.FormaPagamento);
                command.Parameters.AddWithValue("@frete", venda.Frete);
                command.Parameters.AddWithValue("@parcelamento", venda.Parcelamento);
                command.Parameters.AddWithValue("@itemVenda", venda.ItemVenda.CodItemVenda);
                command.Parameters.AddWithValue("@itemProduto", venda.ItemVenda.Produto.CodProduto);
                command.Parameters.AddWithValue("@itemLivro", venda.ItemVenda.Livro.CodLivro);
                command.Parameters.AddWithValue("@observacoes", venda.Observacao);
                
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

       
        public void EditarVenda(Venda venda)
        {
            try
            {
                conectar();

                command = new MySqlCommand("update venda set nome_cliente = @nomeCli, telefoneCli = @telefoneCli, data_venda = @dataVenda, " +
                "Prazo_codCondicao_Pagamento = @condicaoPagamento, forma_pagamento = @formaPagamento, frete = @frete, parcelamento = @parcelamento, " +
                "observacoes = @observacoes where codVenda = @codVenda", conexao);

                command.Parameters.AddWithValue("@nomeCli", venda.NomeCliente);
                command.Parameters.AddWithValue("@telefoneCli", venda.Telefone);
                command.Parameters.AddWithValue("@dataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@condicaoPagamento", venda.CodPrazo.CodCondPagamento);
                command.Parameters.AddWithValue("@formaPagamento", venda.FormaPagamento);
                command.Parameters.AddWithValue("@frete", venda.Frete);
                command.Parameters.AddWithValue("@parcelamento", venda.Parcelamento);
                command.Parameters.AddWithValue("@observacoes", venda.Observacao);
                command.Parameters.AddWithValue("@codVenda", venda.CodVenda);
                
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
        public void ExcluirVenda(Venda venda)
        {
            try
            {
                conectar();

                command = new MySqlCommand("delete from venda where codVenda = @codVenda", conexao);
                command.Parameters.AddWithValue("@codVenda", venda.CodVenda);
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

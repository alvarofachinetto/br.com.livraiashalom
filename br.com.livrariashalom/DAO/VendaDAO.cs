using br.com.livrariashalom.Model;
using br.com.livrariashalom.View;
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
                Conectar();

                command = new MySqlCommand("insert into venda (nome_cliente, telefoneCli, data_venda, LoginFuncionario_codUsuario, Prazo_codCondicao_Pagamento, forma_pagamento, frete,  observacao)" +
                " values (@nomeCli, @telefoneCli, @dataVenda, @codFuncionario, @condicaoPagamento, @formaPagamento, @frete, @observacao)", conexao);

                command.Parameters.AddWithValue("@nomeCli", venda.NomeCliente);
                command.Parameters.AddWithValue("@telefoneCli", venda.Telefone);
                command.Parameters.AddWithValue("@dataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@codFuncionario", venda.LoginFuncionario.CodFuncionario);
                command.Parameters.AddWithValue("@condicaoPagamento", venda.Prazo.CodCondPagamento);
                command.Parameters.AddWithValue("@formaPagamento", venda.FormaPagamento);
                command.Parameters.AddWithValue("@frete", venda.Frete);
                command.Parameters.AddWithValue("@observacao", venda.Observacao);
                
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

        public void EditarVenda(Venda venda)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update venda set nome_cliente = @nomeCli, telefoneCli = @telefoneCli, data_venda = @dataVenda, " +
                "Prazo_codCondicao_Pagamento = @condicaoPagamento, forma_pagamento = @formaPagamento, frete = @frete, parcelamento = @parcelamento, " +
                "observacoes = @observacoes where codVenda = @codVenda", conexao);

                command.Parameters.AddWithValue("@nomeCli", venda.NomeCliente);
                command.Parameters.AddWithValue("@telefoneCli", venda.Telefone);
                command.Parameters.AddWithValue("@dataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@condicaoPagamento", venda.Prazo.CodCondPagamento);
                command.Parameters.AddWithValue("@formaPagamento", venda.FormaPagamento);
                command.Parameters.AddWithValue("@frete", venda.Frete);
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
                Desconectar();
            }
        }

        //Metodo excluir
        public void ExcluirVenda(long codVenda)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from venda where codVenda = @codVenda", conexao);
                command.Parameters.AddWithValue("@codVenda", codVenda);
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

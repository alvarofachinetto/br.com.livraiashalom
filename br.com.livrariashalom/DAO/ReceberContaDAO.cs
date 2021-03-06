﻿using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.DAO
{
    public class ReceberContaDAO : Conexao
    {

        MySqlCommand command = null;

        public void SalvarPagarConta(ReceberConta receberConta)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into receberconta (data, descricao, valor) values (@data, @descricao, @valor)", conexao);
                command.Parameters.AddWithValue("@data", receberConta.Data);
                command.Parameters.AddWithValue("@descricao", receberConta.Descricao);
                command.Parameters.AddWithValue("@valor", receberConta.Valor);
                
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

        public DataTable ListarReceberConta()
        {
            try
            {
                Conectar();
                ReceberConta receberConta = new ReceberConta();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from receberconta where data = curdate()", conexao);
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dt);

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

        public void EditarContaPagar(ReceberConta receberConta)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update receberconta set data = @data, descricao = @descricao, valor = @valor where codReceberConta = @codReceberConta", conexao);
                command.Parameters.AddWithValue("@data", receberConta.Data);
                command.Parameters.AddWithValue("@descricao", receberConta.Descricao);
                command.Parameters.AddWithValue("@valor", receberConta.Valor);
                command.Parameters.AddWithValue("@codReceberConta", receberConta.CodReceberConta);

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
        public void ExcluirReceberConta(long codReceberConta)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from receberconta where codReceberConta = @codReceberConta", conexao);
                command.Parameters.AddWithValue("@codReceberConta", codReceberConta);

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

        //listar o hitorico
        public DataTable ListarHistoricoContaReceber()
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from receberconta", conexao);
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dt);

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

        public DataTable PesquisarContaReceber(DateTime data)
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from receberconta where data = @data", conexao);
                command.Parameters.AddWithValue("@data", data);
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dt);

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
    }
}

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
    public class FluxoCaixaDAO : Conexao
    {
        MySqlCommand command = null;

        public void SalvarFluxo(FluxoCaixa fluxoCaixa)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into fluxocaixa (dia, observacoes, valorEntrada, valorSaida, saldo, valorPrevisto) " +
                "values (@dia, @observacoes, @valorEntrada, @valorSaida, @saldo, @valorPrevisto)", conexao);
                command.Parameters.AddWithValue("@dia", fluxoCaixa.Dia);
                command.Parameters.AddWithValue("@observacoes", fluxoCaixa.Observacoes);
                command.Parameters.AddWithValue("@valorEntrada", fluxoCaixa.ValorEntrada);
                command.Parameters.AddWithValue("@valorSaida", fluxoCaixa.ValorSaida);
                command.Parameters.AddWithValue("@saldo", fluxoCaixa.Saldo);
                command.Parameters.AddWithValue("@valorPrevisto", fluxoCaixa.ValorPrevisto);
                

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

        public DataTable ListarFluxoCaixa()
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from fluxocaixa", conexao);
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

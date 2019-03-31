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
    public class FluxoCaixaDAO : Conexao
    {
        MySqlCommand command = null;

        public void SalvarPagarConta(FluxoCaixa fluxoCaixa)
        {
            try
            {
                conectar();

                command = new MySqlCommand("insert into fluxocaixa (dia, observacoes, valorEntrada, valorSaida, saldo, valorPrevisto, PagarConta_idPagarConta, ReceberConta_idReceberConta) " +
                "values (@dia, @observacoes, @valorEntrada, @valorSaida, @saldo, @valorPrevisto, @codPagarConta, @codReceberConta)");
                command.Parameters.AddWithValue("@dia", fluxoCaixa.Dia);
                command.Parameters.AddWithValue("@observacoes", fluxoCaixa.Observacoes);
                command.Parameters.AddWithValue("@valorEntrada", fluxoCaixa.ValorEntrada);
                command.Parameters.AddWithValue("@valorSaida", fluxoCaixa.ValorSaida);
                command.Parameters.AddWithValue("@saldo", fluxoCaixa.Saldo);
                command.Parameters.AddWithValue("@valorPrevisto", fluxoCaixa.ValorPrevisto);
                command.Parameters.AddWithValue("@codPagarConta", fluxoCaixa.PagarConta.CodPagarConta);
                command.Parameters.AddWithValue("@codReceberConta", fluxoCaixa.ReceberConta);


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

        public DataTable ListarFluxoCaixa()
        {
            try
            {
                conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from fluxocaixa");
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
                desconectar();
            }
        }

     
    }
}

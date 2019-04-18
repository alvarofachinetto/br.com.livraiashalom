using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.DAO
{
    public class PrazoDAO : Conexao
    {

        MySqlCommand command = null;

        //salvar Prazo
        public void SalvarPrazo(Prazo prazo)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into prazo (condicao_pagamento) value (@condicao_pagamento)", conexao);

                command.Parameters.AddWithValue("@condicao_pagamento", prazo.CondPagamento);
                
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

        public void DeletarPrazo(Prazo prazo)
        {
            Conectar();

            command = new MySqlCommand("delete from prazo where codCondicao_pagamento = @codCondPagamento");

            command.Parameters.AddWithValue("@codCondPagamento", prazo.CodCondPagamento);
        }

    }
}

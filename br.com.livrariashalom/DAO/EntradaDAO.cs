using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace br.com.livrariashalom.DAO
{
    public class EntradaDAO : Conexao
    {
        private MySqlCommand command = null;

        //salvar contato
        public void SalvarEntrada(Entrada entrada)
        {
            try
            {
                Conectar();


                command = new MySqlCommand("insert into entrada (data, qtdEntrada, descricao, Livro_codLivro) " +
                "values (@data, @qtdSaida, @descricao, @codLivro)", conexao);

                command.Parameters.AddWithValue("@data", entrada.Data);
                command.Parameters.AddWithValue("@qtdSaida", entrada.QtdEntrada);
                command.Parameters.AddWithValue("@descricao", entrada.Descricao);
                command.Parameters.AddWithValue("@codLivro", entrada.CodLivro.CodLivro);
                command.ExecuteNonQuery();

                //diminui a qtd do livro
                command = new MySqlCommand("update livro set qtd = (qtd + @qtdSaida) where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@qtdSaida", entrada.QtdEntrada);
                command.Parameters.AddWithValue("@codLivro", entrada.CodLivro.CodLivro);
                command.ExecuteNonQuery();

                MessageBox.Show("Entrada realizada com sucesso");
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

        public DataTable ListarEntrada()
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from entrada order by data", conexao);

                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);//adiciona ou atualiza as linhas 

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

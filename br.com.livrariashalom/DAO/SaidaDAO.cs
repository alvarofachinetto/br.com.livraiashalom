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
    public class SaidaDAO : Conexao
    {
        private MySqlCommand command = null;

        //salvar contato
        public void SalvarSaida(Saida saida)
        {
            try
            {
                Conectar();
                

                command = new MySqlCommand("insert into saida (data, qtdSaida, descricao, Livro_codLivro) " +
                "values (@data, @qtdSaida, @descricao, @codLivro)", conexao);

                command.Parameters.AddWithValue("@data", saida.Data);
                command.Parameters.AddWithValue("@qtdSaida", saida.QtdSaida);
                command.Parameters.AddWithValue("@descricao", saida.Descricao);
                command.Parameters.AddWithValue("@codLivro", saida.CodLivro.CodLivro);
                command.ExecuteNonQuery();

                //diminui a qtd do livro

                command = new MySqlCommand("select qtd from livro where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@codLivro", saida.CodLivro.CodLivro);
                MySqlDataReader dr = command.ExecuteReader();
                int qtdEstoque = 0;
                while (dr.Read())
                {
                    qtdEstoque = dr.GetInt32("qtd");
                    MessageBox.Show("Baixa realizada com sucesso");
                }
                dr.Close();

                if (qtdEstoque > saida.QtdSaida)
                {
                    command = new MySqlCommand("update livro set qtd = (qtd - @qtdSaida) where codLivro = @codLivro", conexao);
                    command.Parameters.AddWithValue("@qtdSaida", saida.QtdSaida);
                    command.Parameters.AddWithValue("@codLivro", saida.CodLivro.CodLivro);
                    command.ExecuteNonQuery();

                }
                else
                {
                    MessageBox.Show("Quantidade não suficiente para realizar baixa");
                }

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

        public DataTable ListarSaida()
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from saida order by data", conexao);

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

        public void ExcluirSaida(Saida saida)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from saida where codSaida= @codSaida", conexao);
                command.Parameters.AddWithValue("@codSaida", saida.CodSaida);
                command.ExecuteNonQuery();

                //devolve a qtd original
                command = new MySqlCommand("update livro set qtd = (qtd + @qtdSaida) where codLivro = @codLivro", conexao);
                command.Parameters.AddWithValue("@qtdSaida", saida.QtdSaida);
                command.Parameters.AddWithValue("@codLivro", saida.CodLivro.CodLivro);
                command.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}

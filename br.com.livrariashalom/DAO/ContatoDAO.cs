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
    class ContatoDAO : Conexao
    {
        private MySqlCommand command = null;

        //salvar contato
        public void SalvarContato(Contato contato)
        {
            try
            {
                Conectar();
                
                
                command = new MySqlCommand("insert into contato (email_primario, email_secundario, telefone_principal, telefone_reserva, Fornecedor_codFornecedor) " +
                "values (@email_primario, @email_secundario, @telefone_principal, @telefone_reserva, @codFornecedor)", conexao); 

                command.Parameters.AddWithValue("@email_primario", contato.EmailPrimario);
                command.Parameters.AddWithValue("@email_secundario", contato.EmailSecundario);
                command.Parameters.AddWithValue("@telefone_principal", contato.TelefonePrincipal);
                command.Parameters.AddWithValue("@telefone_reserva", contato.TelefoneReserva);
                command.Parameters.AddWithValue("@codFornecedor", contato.Fornecedor.CodFornecedor);


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

        //Metodo listar contato
        public DataTable ListarContato()
        {
            try
            {

                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from contato", conexao);

                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);

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
        public void EditarContato(Contato contato)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update contato set email_primario = @email_primario, email_secundario = @email_secundario," +
                " telefone_principal = @telefone_principal, telefone_reserva = @telefone_reserva, Fornecedor_codFornecedor = @codFornecedor where codContato = @codContato", conexao);

                command.Parameters.AddWithValue("@email_primario", contato.EmailPrimario);
                command.Parameters.AddWithValue("@email_secundario", contato.EmailSecundario);
                command.Parameters.AddWithValue("@telefone_principal", contato.TelefonePrincipal);
                command.Parameters.AddWithValue("@telefone_reserva", contato.TelefoneReserva);
                command.Parameters.AddWithValue("@codFornecedor", contato.Fornecedor.CodFornecedor);
                command.Parameters.AddWithValue("@codContato", contato.CodContato);

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
        public void ExcluirContato(Contato contato)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("delete from contato where codContato = @codContato", conexao);
                command.Parameters.AddWithValue("@codContato", contato.CodContato);
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

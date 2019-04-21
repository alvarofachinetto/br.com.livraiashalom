using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using br.com.livrariashalom.Model;
using System.Data;
using System.Windows;

namespace br.com.livrariashalom.DAO
{
    public class LoginFuncionarioDAO : Conexao
    {
        MySqlCommand command = null;

        //método salvar
        public void SalvarLogin(LoginFuncionario login)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("insert into loginfuncionario (usuario, senha, confirmacao_senha, tipo_usuario) values " +
                "(@usuario, @senha, @confSenha, @tipousuario)", conexao); //conexao está referente as infos do banco
                //parameters são os @value, AddWithValue são as variaveis de classe login 
                command.Parameters.AddWithValue("@usuario", login.Funcionario);
                command.Parameters.AddWithValue("@senha", login.Senha);
                command.Parameters.AddWithValue("@confirmacao_senha", login.ConfSenha);
                command.Parameters.AddWithValue("@tipo_usuario", login.TipoFuncionario);

                command.ExecuteNonQuery();
            }
            catch(Exception error)
            {
                throw error;
            }
            finally
            {
                Desconectar();
            }
        }

        //Metodo listar 
        public DataTable ListarLogin()
        {
            try
            {

                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                command = new MySqlCommand("select * from loginfuncionario", conexao);

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
        //metodo editar
        public void EditarLogin(LoginFuncionario login)
        {
            try
            {
                Conectar();

                command = new MySqlCommand("update loginfuncionario set usuario = @usuario, senha = @senha, " +
                "confirmacao_senha = @confirmacao_senha, tipo_usuario = @tipo_usuario where codUsuario = @codUsuario", conexao);

                command.Parameters.AddWithValue("@codUsuario", login.CodFuncionario);
                command.Parameters.AddWithValue("@usuario", login.Funcionario);
                command.Parameters.AddWithValue("@senha", login.Senha);
                command.Parameters.AddWithValue("@confSenha", login.ConfSenha);
                command.Parameters.AddWithValue("@tipousuario", login.TipoFuncionario);

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
        public void ExcluirLogin(LoginFuncionario login)
        {
            try
            {

                Conectar();

                command = new MySqlCommand("delete from loginfuncionario where codUsuario = @codUsuario", conexao);
                command.Parameters.AddWithValue("@codUsuario", login.CodFuncionario);
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

        //metodo para entrar no sistema 
        public void Logar(LoginFuncionario login)
        {
            try
            {

                Conectar();
                command = new MySqlCommand("select * from loginfuncionario where usuario = @usuario and senha = @senha", conexao);

                command.Parameters.AddWithValue("@usuario", login.Funcionario);
                command.Parameters.AddWithValue("@senha", login.Senha);

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
    }

}

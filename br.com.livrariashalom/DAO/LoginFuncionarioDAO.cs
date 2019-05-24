using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using br.com.livrariashalom.Model;
using System.Data;
using System.Windows;
using br.com.livrariashalom.View;

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
                command.Parameters.AddWithValue("@confSenha", login.ConfSenha);
                command.Parameters.AddWithValue("@tipousuario", login.TipoFuncionario);

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

                //seleciona o codigo do funcionario
                command = new MySqlCommand("select codUsuario from loginfuncionario where usuario = @usuario", conexao);
                command.Parameters.AddWithValue("@usuario", login.Funcionario);

                command.ExecuteNonQuery();
                MySqlDataReader dr = command.ExecuteReader();

                long codigo = 0;

                while (dr.Read())
                {//recebe o codigo
                    login.CodFuncionario = Convert.ToInt32(dr["codUsuario"]);

                    codigo = login.CodFuncionario;
                }
                dr.Close();

                command = new MySqlCommand("update loginfuncionario set usuario = @usuario, senha = @senha, " +
                "confirmacao_senha = @confSenha, tipo_usuario = @tipoUsuario where usuario = @usuario", conexao);

                command.Parameters.AddWithValue("@codUsuario", codigo); //executa com o código selecionado
                command.Parameters.AddWithValue("@usuario", login.Funcionario);
                command.Parameters.AddWithValue("@senha", login.Senha);
                command.Parameters.AddWithValue("@confSenha", login.ConfSenha);
                command.Parameters.AddWithValue("@tipoUsuario", login.TipoFuncionario);

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

                //seleciona o codigo do funcionario
                command = new MySqlCommand("select codUsuario from loginfuncionario where usuario = @usuario",conexao);
                command.Parameters.AddWithValue("@usuario", login.Funcionario);

                command.ExecuteNonQuery();
                MySqlDataReader dr = command.ExecuteReader();

                long codigo = 0;

                while (dr.Read())
                {//recebe o codigo
                    login.CodFuncionario = Convert.ToInt32(dr["codUsuario"]);

                    codigo = login.CodFuncionario;
                }
                dr.Close();

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
                command = new MySqlCommand("select usuario, senha from loginfuncionario where usuario = @usuario and senha = @senha", conexao);
                command.Parameters.AddWithValue("@usuario", login.Funcionario);
                command.Parameters.AddWithValue("@senha", login.Senha);
                command.ExecuteNonQuery();

                Boolean autenticar = command.ExecuteReader().HasRows;//verifica a informação no banco

                TelaLogin telaLogin = new TelaLogin();

                //verificar a autencação da senha
                //while (telaLogin.Close() == true)
                //{

                
                if (autenticar == true)
                {
                    MessageBox.Show("Welcome !");
                    TelaPrincipal telaPrincipal = new TelaPrincipal();
                    telaPrincipal.Show();
                    telaLogin.Close();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou senha incorretos");
                    
                }

                //}
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
           
        }
    }

}

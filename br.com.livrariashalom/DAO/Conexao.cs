using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace br.com.livrariashalom.DAO
{
    public class Conexao
    {
        String conecta = "DATABASE = livraria_shalom; SERVER=Localhost; UID=root; PWD=3303";
        protected MySqlConnection conexao = null;
        MySqlCommand comando = null;

        public void conectar()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally{
                conexao.Close();
            }
        }

        public void desconectar()
        {
            try
            {
                conexao = new MySqlConnection();
                conexao.Close();
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}

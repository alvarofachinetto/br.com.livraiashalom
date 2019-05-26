using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace br.com.livrariashalom.DAO
{
    public class Conexao
    {
        public MySqlConnection conexao;


        public MySqlConnection Conectar()
        {
            try
            {
                conexao = new MySqlConnection("server = localhost; database=livraria_shalom;  UID=root; pwd=;");
                
                conexao.Open();
                
                return conexao;
            }
            catch(Exception erro)
            {
                throw erro;
            }
           
        }

        public void Desconectar()
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
         
        }
    }
}

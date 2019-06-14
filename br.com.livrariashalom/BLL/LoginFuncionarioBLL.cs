using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace br.com.livrariashalom.BLL
{
    public class LoginFuncionarioBLL
    {
        private LoginFuncionarioDAO loginFuncionarioDAO = new LoginFuncionarioDAO();

        public void SalvarFuncionario(LoginFuncionario login)
        {
            try
            {
                loginFuncionarioDAO.SalvarLogin(login);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        public void EditarFuncionario(LoginFuncionario login)
        {
            try
            {
                loginFuncionarioDAO.EditarLogin(login);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        public void ExcluirFuncionario(LoginFuncionario login)
        {
            try
            {
                loginFuncionarioDAO.ExcluirLogin(login);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        public DataTable ListarFuncionario()
        {
            
            try
            {
                DataTable dt = new DataTable();
                dt = loginFuncionarioDAO.ListarLogin();
                return dt;

            }
            catch (Exception error)
            {
                throw error;
            }
            
        }
    }

}

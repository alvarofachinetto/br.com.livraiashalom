using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace br.com.livrariashalom.BLL
{
    public class LoginFuncionarioBLL
    {
        private LoginFuncionarioDAO loginFuncionarioDAO = new LoginFuncionarioDAO();

        public void Logar(LoginFuncionario login)
        {
            try
            {
                loginFuncionarioDAO.Logar(login);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            
        }

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
    }
}

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
    public class ContatoBLL
    {
        private ContatoDAO contatoDAO = new ContatoDAO();

        public void SavarContato(Contato contato)
        {
            try
            {
                this.contatoDAO = new ContatoDAO();
                contatoDAO.SalvarContato(contato);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
    }
}

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
    
    public class PrazoBLL
    {
        private PrazoDAO prazoDAO = new PrazoDAO();

        public void SalvaPrazo(Prazo prazo)
        {
            try
            {
                prazoDAO.SalvarPrazo(prazo);
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        } 
    }
}

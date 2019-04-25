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
    
    public class PagarContaBLL
    {
        private PagarContaDAO pagarContaDAO = new PagarContaDAO();

        public void SalvarContaPagar(PagarConta pagarConta)
        {
            try
            {
                pagarContaDAO.SalvarPagarConta(pagarConta);
            }catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }
    }
}

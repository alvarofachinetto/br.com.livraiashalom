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
    public class ReceberContaBLL
    {
        private ReceberContaDAO receberContaDAO = new ReceberContaDAO ();

        public void SalvarReceberConta(ReceberConta receberConta)
        {
            try{

                receberContaDAO.SalvarPagarConta(receberConta);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            
        }

    }
}

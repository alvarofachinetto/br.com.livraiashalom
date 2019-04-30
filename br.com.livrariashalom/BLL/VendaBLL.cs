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

    public class VendaBLL
    {
        private VendaDAO vendaDAO = new VendaDAO();

        public void SalvarVenda(Venda venda)
        {
            try
            {
                vendaDAO.SalvarVenda(venda);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }

        }
    }
}

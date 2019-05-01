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
    public class ItemVendaBLL
    {
        private ItemVendaDAO itemVendaDAO = new ItemVendaDAO();

        public void SalvarItem(ItemVenda itemVenda)
        {
            try
            {
                itemVendaDAO.SalvarItemVenda(itemVenda);
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }
    }
}

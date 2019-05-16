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

        public DataTable ListarItem(ItemVenda itemVenda)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = itemVendaDAO.ListarItemVenda(itemVenda);

                return dt;
            }
            catch (Exception error)
            {
                throw error;

            }

        }

        public void VendaLivro(long codVenda)
        {
            try
            {
                itemVendaDAO.VendaLivro(codVenda);

            }
            catch (Exception error)
            {
                throw error;

            }
        }

        public void SomarSubTotal(long codVenda)
        {
            try
            {
                itemVendaDAO.SomarSubtotal(codVenda);

            }
            catch (Exception error)
            {
                throw error;

            }
        }

    }
}

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

        public void EditarReceberConta(ReceberConta receberConta)
        {
            try
            {

                receberContaDAO.EditarContaPagar(receberConta);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        public void ExcluirReceberConta(long codReceberConta)
        {
            try
            {

                receberContaDAO.ExcluirReceberConta(codReceberConta);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        public DataTable ListarReceberConta()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = receberContaDAO.ListarReceberConta();

                return dt;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public DataTable PesquisarContaReceber(DateTime data)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = receberContaDAO.PesquisarContaReceber(data);

                return dt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}

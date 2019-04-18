using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;

namespace br.com.livrariashalom.BLL
{
    public class FornecedorBLL
    {
        private FornecedorDAO fornecedorDAO = new FornecedorDAO();
       
        //metodo para receber informações do usuario e mandar para o dal
        public void SalvarFornecedor(Fornecedor fornecedor)
        {
            
            try
            {
                fornecedorDAO.SalvarFornecedor(fornecedor);
            }
            catch(Exception error)
            {
                MessageBox.Show("erro: " + error);
            }
        }

        public DataTable ListarFornecedor()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = fornecedorDAO.ListarFornecedor();

                return dt;
            }
            catch(Exception error)
            {
                throw error;
                
            }
            
        }

        public void EditarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                fornecedorDAO.EditarFornecedor(fornecedor);
            }catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        public void DeletarFornecedor(Fornecedor fornecedor)
        {
            fornecedorDAO.DeletarFornecedor(fornecedor);
        }
    }
}

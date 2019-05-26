using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.BLL
{
    public class EstoqueBLL
    {
        private EstoqueDAO estoqueDAO = new EstoqueDAO();

        public void SalvarLivroEsoque(Estoque estoque)
        {
            try
            {
                estoqueDAO.SalvarLivro(estoque);
            }catch(Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ListarLivroEsoque()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = estoqueDAO.ListarEstoque();

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}

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
    public class ProdutoBLL
    {
        private ProdutoDAO produtoDAO = new ProdutoDAO();

        public void SalvarProduto(Produto produto)
        {
            try
            {
                produtoDAO.SalvarProduto(produto);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }
    }
}

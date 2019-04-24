using br.com.livrariashalom.DAO;
using br.com.livrariashalom.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace br.com.livrariashalom.BLL
{
    public class LivroBLL
    {
        private LivroDAO livroDAO = new LivroDAO();

        public void SalvarLivro(Livro livro)
        {
            try
            {
                livroDAO.SalvarLivro(livro);
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            
        }
    }
}

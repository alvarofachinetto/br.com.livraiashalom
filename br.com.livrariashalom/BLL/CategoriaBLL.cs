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
    public class CategoriaBLL
    {
        private CategoriaDAO categoriaDao = new CategoriaDAO();

        public void SalvarCategoria(Categoria categoria)
        {
            try
            {
                categoriaDao.SalvarCategoria(categoria);
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }   
        }

        public void EditarCategoria(Categoria categoria)
        {
            try
            {
                categoriaDao.EditarCategoria(categoria);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        public void ExcluirCategoria(Categoria categoria)
        {
            try
            {
                categoriaDao.ExcluirCategoria(categoria);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

    }
}

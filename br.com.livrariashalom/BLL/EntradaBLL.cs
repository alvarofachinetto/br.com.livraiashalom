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
    public class EntradaBLL
    {
        private EntradaDAO entradaDAO = new EntradaDAO();

        public bool SalvarEntrada(Entrada entrada)
        {
            try
            {
                if (entrada.CodLivro == null || entrada.Data == null || entrada.QtdEntrada == 0)
                {
                    MessageBox.Show("Obrigatório o preenchimeto dos campos com *");
                    return false;
                }
                else
                {
                    entradaDAO.SalvarEntrada(entrada);
                    return true;
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ListarEntrada()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = entradaDAO.ListarEntrada();

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public bool ExcluirEntrada(Entrada entrada)
        {
            try
            {
                if (entrada.CodEntrada == null || entrada.CodLivro == null || entrada.Data == null || entrada.QtdEntrada == 0)
                {
                    MessageBox.Show("Obrigatório o preenchimeto dos campos com *");
                    return false;
                }
                else
                {
                    entradaDAO.ExcluirEntrada(entrada);
                    return true;
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}

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
    public class SaidaBLL
    {
        private SaidaDAO saidaDAO = new SaidaDAO();
        

        public bool SalvarSaida (Saida saida)
        {
            try
            {
                if (saida.CodLivro == null || saida.Data == null || saida.QtdSaida == 0)
                {
                    MessageBox.Show("Obrigatório o preenchimeto dos campos com *");
                    return false;
                }
                else
                {
                    saidaDAO.SalvarSaida(saida);
                    return true;
                }
            }catch(Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ListarSaida()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = saidaDAO.ListarSaida();

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public bool ExcluirSaida(Saida saida)
        {
            try
            {
                if (saida.CodSaida == null || saida.CodLivro == null || saida.Data == null || saida.QtdSaida== 0)
                {
                    MessageBox.Show("Obrigatório o preenchimeto dos campos com *");
                    return false;
                }
                else
                {
                    saidaDAO.ExcluirSaida(saida);
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

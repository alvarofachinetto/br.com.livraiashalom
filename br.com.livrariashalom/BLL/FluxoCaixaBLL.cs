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
    public class FluxoCaixaBLL
    {
        private FluxoCaixaDAO fluxoCaixaDAO = new FluxoCaixaDAO();

        public void SalvarFluxo(FluxoCaixa fluxoCaixa)
        {
            try
            {
                fluxoCaixaDAO.SalvarFluxo(fluxoCaixa);
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        public DataTable ListarFluxo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = fluxoCaixaDAO.ListarFluxoCaixa();
                return dt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}

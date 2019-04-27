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
             
    }
}

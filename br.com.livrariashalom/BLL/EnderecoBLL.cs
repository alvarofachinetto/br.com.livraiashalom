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
    public class EnderecoBLL
    {
        private EnderecoDAO EnderecoDAO = new EnderecoDAO();

        public void SalvarEndereco(Endereco endereco)
        {
            try
            {
                EnderecoDAO.SalvarEndereco(endereco);
            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
            
        }

    }
}

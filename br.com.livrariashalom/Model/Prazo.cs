using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class Prazo
    {
        private long codCondPagamento;
        private String condPagamento;
        

        public long CodCondPagamento
        {
            get { return codCondPagamento; }
            set { codCondPagamento = value; }
        }

        public String CondPagamento
        {
            get { return condPagamento; }
            set { condPagamento = value; }
        }

        
    }
}

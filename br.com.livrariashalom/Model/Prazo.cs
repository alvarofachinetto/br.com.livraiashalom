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
        private int parcelamento;
        

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

        public int Parcelamento
        {
            get { return parcelamento; }
            set { parcelamento = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    
    public class PagarConta
    {
        private long codPagarConta;
        private DateTime data;
        private String descricao;
        private double valor;
        

        public long CodPagarConta
        {
            get { return codPagarConta; }
            set { codPagarConta = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }


    }
}

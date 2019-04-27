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
        private DateTime dataVencimento;
        private String status;

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

        public DateTime DataVencimento
        {
            get { return dataVencimento; }
            set { dataVencimento = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public enum StatusPagar
    {
        Pago, Pagar
    }

    public class PagarConta
    {
        private long codPagarConta;
        private String data;
        private String descricao;
        private double valor;
        private String dataVencimento;
        private StatusPagar status;

        public long CodPagarConta
        {
            get { return codPagarConta; }
        }

        public String Data
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

        public String DataVencimento
        {
            get { return dataVencimento; }
            set { dataVencimento = value; }
        }

        public StatusPagar Status
        {
            get { return status; }
            set { status = value; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    

    public class ReceberConta
    {
        private long codReceberConta;
        private DateTime data;
        private String descricao;
        private double valor;
        private String status;

        public long CodReceberConta
        {
            get { return codReceberConta; }
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

      
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}

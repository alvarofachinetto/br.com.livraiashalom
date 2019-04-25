using br.com.livrariashalom.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class FluxoCaixa
    {
        private long codFluxo;
        private String dia;
        private double valorPrevisto;
        private String observacoes;
        private double valorEntrada;
        private double valorSaida;
        private double saldo;
        private PagarConta pagarConta;
        private ReceberConta receberConta;
        
        public long CodFluxo
        {
            get { return codFluxo; }
            set { codFluxo = value; }
        }

        public String Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        public double ValorPrevisto
        {
            get { return valorPrevisto; }
            set { valorPrevisto = value; }
        }

        public String Observacoes
        {
            get { return observacoes; }
            set { observacoes = value; }
        }

        public double ValorEntrada
        {
            get { return valorEntrada; }
            set { valorEntrada = value; }
        }

        public double ValorSaida
        {
            get { return valorSaida; }
            set { valorSaida = value; }
        }

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public ReceberConta ReceberConta
        {
            get { return receberConta; }
            set { receberConta = value; }
        }

        public PagarConta PagarConta
        {
            get { return pagarConta; }
            set { pagarConta = value; }
        }

    }
}

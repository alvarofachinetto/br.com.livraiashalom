using br.com.livrariashalom.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
   
    public class Venda
    {
        private long codVenda;
        private String nomeCliente;
        private String telefoneCli;
        private DateTime dataVenda;
        private Prazo prazo = new Prazo();
        private double frete;
        private String formaPagamento;
        private LoginFuncionario loginFuncionario = new LoginFuncionario();
        private String observacao;
        
        public long CodVenda
        {
            get { return codVenda; }
            set { codVenda = value; }
        }

        public String NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        public DateTime DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }


        public String FormaPagamento
        {
            get { return formaPagamento; }
            set { formaPagamento = value; }
        }

        public double Frete
        {
            get { return frete; }
            set { frete = value; }
        }

        public String Telefone
        {
            get { return telefoneCli; }
            set { telefoneCli = value; }
        }

        public LoginFuncionario LoginFuncionario
        {
            get { return loginFuncionario; }
            set { loginFuncionario = value; }
        }

        public String Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        
        public Prazo Prazo { get => prazo; set => prazo = value; }
    }
}

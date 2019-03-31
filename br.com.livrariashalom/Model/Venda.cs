using br.com.livrariashalom.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public enum FormaPagamento
    {
        Credito, Debito, Dinheiro
    }

    public class Venda
    {
        private long codVenda;
        private String nomeCliente;
        private String telefoneCli;
        private String dataVenda;
        private double frete;
        private FormaPagamento formaPagamento;
        private Prazo codPrazo;
        private LoginFuncionario loginFuncionario;
        private int parcelamento;
        private ItemVenda itemVenda;
        private String observacao;

        public long CodVenda
        {
            get { return codVenda; }
        }

        public String NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        public String DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }

        
        public FormaPagamento FormaPagamento
        {
            get { return formaPagamento; }
            set { formaPagamento = value; }
        }

        public Prazo CodPrazo
        {
            get { return codPrazo; }
            set { codPrazo = value; }
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

        public int Parcelamento
        {
            get { return parcelamento; }
            set { parcelamento = value; }
        }

        public ItemVenda ItemVenda
        {
            get { return itemVenda; }
            set { itemVenda = value; }
        }

        public String Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

    }
}

using br.com.livrariashalom.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class ItemVenda
    {

        private long codItemVenda;
        private int quantidade;
        private double subTotal;
        private double valorTot;
        private double preco;
        private long info;

        public long CodItemVenda
        {
            get { return codItemVenda; }
            set { codItemVenda = value; }
        }

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public double SubTotal {
            get {return subTotal; }
            set { subTotal = value; }
        }

        public double ValorTotal
        {
            get {return valorTot; }
            set { valorTot = value; }
        }

        public double Preco { get => preco; set => preco = value; }
        public long Info { get => info; set => info = value; }
    }
}

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
        private Venda venda = new Venda();
        private Livro livro = new Livro();
        
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

        public Venda Venda { get => venda; set => venda = value; }
        public Livro Livro { get => livro; set => livro = value; }
    }
}

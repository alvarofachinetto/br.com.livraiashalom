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
        private Produto produto = new Produto();
        private Livro livro = new Livro();
        private Venda venda = new Venda();

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

        public Produto Produto
        {
            get {return produto; }
            set { produto = value; }
        }
        public Livro Livro
        {
            get {return livro; }
            set { livro = value; }
        }
        public Venda Venda
        {
            get { return venda; }
            set { venda = value; }
        }

    }
}

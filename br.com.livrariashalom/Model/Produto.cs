using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class Produto
    {
        private long codProduto;
        private String nomeProduto;
        private double valorUnit;
        private String categoria;
        private int qtd;
        private int qtdAlerta;
        private Fornecedor fornecedor;

        public long CodProduto
        {
            get { return codProduto; }
        }

        public String NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        public double ValorUnit
        {
            get { return valorUnit; }
            set { valorUnit = value; }
        }

        public String Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public int Qtd
        {
            get { return qtd; }
            set { qtd = value; }
        }

        public int QtdAlerta
        {
            get { return qtdAlerta; }
            set { qtdAlerta = value; }
        }

        public Fornecedor Fornecedor
        {
            get { return fornecedor; }
            set { fornecedor = value; }
        }
    }
}

using br.com.livrariashalom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.MODEL
{
   
    public class Livro
    {
        private long codLivro;
        private String titulo;
        private String autor;
        private String editora;
        private String fase;
        private Categoria codCategoria;
        private double valorUnit;
        private String descricao;
        private int qtdAlerta;
        private int qtd;
        private Fornecedor codFornecedor = new Fornecedor();
        
        public long CodLivro
        {
            get{return codLivro;}
            set { codLivro = value; }
        }

        public String Titulo
        {
            get{return titulo;}
            set{titulo = value;}
        }

        public String Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public String Editora
        {
            get { return editora; }
            set { editora = value; }
        }

        public String Fase
        {
            get { return fase; }
            set { fase = value; }
        }

        public int Qtd
        {
            get { return Qtd1; }
            set { Qtd1 = value; }
        }

        public int QtdAlerta
        {
            get { return qtdAlerta; }
            set { qtdAlerta = value; }
        }

        public double ValorUnit
        {
            get { return valorUnit; }
            set { valorUnit = value; }
        }

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public Fornecedor Fornecedor
        {
            get { return codFornecedor; }
            set { codFornecedor = value; }
        }

        public Categoria CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }

        public int Qtd1 { get => qtd; set => qtd = value; }
    }
}

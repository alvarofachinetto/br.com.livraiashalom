﻿using br.com.livrariashalom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.MODEL
{
    public enum CategoriaLivro
    {
        Biblia, Cura, Devocao, Espiritualidade, Estudo_Biblico, Evangelizacao, Familia,
        Formacao_Humana, Ifantil, Jovem, EBook, Literatura, Livros_Ouvir, Maria_Emmir, Santos,
        Teologia, Vocacao
    }

    public class Livro
    {
        private long codLivro;
        private String titulo;
        private String autor;
        private String editora;
        private String fase;
        private int qtd;
        private CategoriaLivro categoriaLivro;
        private double valorUnit;
        private String descricao;
        private int qtdAlerta;
        private Fornecedor codFornecedor;
        
        public long CodLivro
        {
            get{return codLivro;}
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
            get { return qtd; }
            set { qtd = value; }
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

        public CategoriaLivro CategoriaLivro
        {
            get { return categoriaLivro; }
            set { categoriaLivro = value; }
        }

    }
}

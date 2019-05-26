using br.com.livrariashalom.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class Estoque
    {
        private int codRegistro;
        private String livro;
        private int qtdEstoque;
        private int qtdEntrada;
        private int qtdSaida;
        private int qtdAlerta;
        private Livro codLivro;

        public int CodRegistro { get => codRegistro; set => codRegistro = value; }
        public string Livro { get => livro; set => livro = value; }
        public int QtdEstoque { get => qtdEstoque; set => qtdEstoque = value; }
        public int QtdEntrada { get => qtdEntrada; set => qtdEntrada = value; }
        public int QtdSaida { get => qtdSaida; set => qtdSaida = value; }
        public int QtdAlerta { get => qtdAlerta; set => qtdAlerta = value; }
        public Livro CodLivro { get => codLivro; set => codLivro = value; }
    }
}

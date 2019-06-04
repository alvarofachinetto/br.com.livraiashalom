using br.com.livrariashalom.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class Saida
    {
        private int codSaida;
        private int qtdSaida;
        private DateTime data;
        private string descricao;
        private Livro codLivro = new Livro();

        public int CodSaida { get => codSaida; set => codSaida = value; }
        public int QtdSaida { get => qtdSaida; set => qtdSaida = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public Livro CodLivro { get => codLivro; set => codLivro = value; }
    }
}

using br.com.livrariashalom.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class Entrada
    {
        private long codEntrada;
        private int codSaida;
        private int qtdEntrada;
        private DateTime data;
        private string descricao;
        private Livro codLivro = new Livro();

        public int CodSaida { get => codSaida; set => codSaida = value; }
        public int QtdEntrada { get => qtdEntrada; set => qtdEntrada = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public Livro CodLivro { get => codLivro; set => codLivro = value; }
        public long CodEntrada { get => codEntrada; set => codEntrada = value; }
    }
}

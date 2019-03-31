using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class Endereco
    {
        private long codEndereco;
        private String logradouro;
        private int numero;
        private String bairro;
        private String cidade;
        private String estado;
        private String cep;
        private Fornecedor fornecedor;

        public long CodEndereco
        {
            get { return codEndereco; }
        }

        public String Logradouro
        {
            get { return logradouro; }
            set { logradouro = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public String Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public String Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public Fornecedor Fornecedor
        {
            get { return fornecedor; }
            set { fornecedor = value; }
        }
    }
}

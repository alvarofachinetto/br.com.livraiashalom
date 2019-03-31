using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{

    public enum Empresa
    {
        MATRIZ, FILIAL
    }

    public class Fornecedor
    {
        private long codFornecedor;
        private String nomeRazao;
        private String nomeFantasia;
        private String cnpj;
        private String ie;
        private String cpf;
        private String observacoes;
        private Empresa empresa;

        public long CodFornecedor
        {
            get { return codFornecedor; }

        }

        public String NomeRazao
        {
            get { return nomeRazao; }
            set { nomeRazao = value; }
        }

        public String NomeFantasia
        {
            get { return nomeFantasia; }
            set { nomeFantasia = value; }
        }

        public String Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        public String Ie
        {
            get { return ie; }
            set { ie = value; }
        }

        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string Observacoes
        {
            get { return observacoes; }
            set { observacoes = value; }
        }
    }
}

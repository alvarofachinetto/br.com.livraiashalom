using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    
    public class Fornecedor
    {
        private long codFornecedor;
        private String nomeRazao;
        private String nomeFantasia;
        private String cnpjcpf;
        private String ie;
        private String observacoes;
        private String empresa;

        public long CodFornecedor
        {
            get { return codFornecedor; }
            set { codFornecedor = value; }
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

        public String CnpjCpf
        {
            get { return cnpjcpf; }
            set { cnpjcpf = value; }
        }

        public String Ie
        {
            get { return ie; }
            set { ie = value; }
        }

        public String Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        
        public string Observacoes
        {
            get { return observacoes; }
            set { observacoes = value; }
        }
    }
}

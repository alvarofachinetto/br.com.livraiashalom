using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class Contato
    {
        private long codContato;
        private String emailPrimario;
        private String emailSecundario;
        private String telefonePrincipal;
        private String telefoneReserva;
        private Fornecedor fornecedor = new Fornecedor();

        public long CodContato
        {
            get { return codContato; }
            
        }

        public String EmailPrimario
        {
            get { return emailPrimario; }
            set { emailPrimario = value; }
        }

        public String EmailSecundario
        {
            get { return emailSecundario; }
            set { emailSecundario = value; }
        }

        public String TelefonePrincipal
        {
            get { return telefonePrincipal; }
            set { telefonePrincipal = value; }
        }

        public String TelefoneReserva
        {
            get { return telefoneReserva; }
            set { telefoneReserva = value; }
        }

        public Fornecedor Fornecedor
        {
            get {return this.fornecedor; }
            set {this.fornecedor = value; }
        }
    }
}

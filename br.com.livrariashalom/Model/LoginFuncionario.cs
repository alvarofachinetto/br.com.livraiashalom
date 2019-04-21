using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{

    
    public class LoginFuncionario
    {
        private long codUsuario;
        private String usuario;
        private String senha;
        private string confSenha;
        
        public long CodUsuario
        {
            get { return codUsuario; }
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public String ConfSenha
        {
            get { return confSenha; }
            set { confSenha = value; }
        }
        

        public TipoUsuario TipoUsuario
        {
            get { return tipoUsuario; }
            set { tipoUsuario = value; }
        }
    }
}

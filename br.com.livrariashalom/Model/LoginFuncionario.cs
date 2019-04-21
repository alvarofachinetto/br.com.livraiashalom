using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{

    
    public class LoginFuncionario
    {
        private long codFuncionaro;
        private String funcionario;
        private String senha;
        private string confSenha;
        private String tipoFuncionario;

        public long CodFuncionario
        {
            get { return codFuncionaro; }
        }

        public String Funcionario
        {
            get { return funcionario; }
            set { funcionario = value; }
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
        

        public String TipoFuncionario
        {
            get { return tipoFuncionario; }
            set { tipoFuncionario = value; }
        }
    }
}

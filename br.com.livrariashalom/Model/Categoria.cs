using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.livrariashalom.Model
{
    public class Categoria
    {
        private long codCategoria;
        private String categoriaGeral;

        public long CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }

        public String CategoriaGeral
        {
            get { return categoriaGeral; }
            set { categoriaGeral = value; }
        }
    }
}

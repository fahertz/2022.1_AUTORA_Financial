using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial
{
    public class Categoria_Financeira
    {
        public class Tipo_Categoria
        {
            public int idTipo_Categoria { get; set; }
            public string descTipo_Categoria { get; set; }

        }

        public class Categoria
        {
             public int idCategoria { get; set; }
             public string descCategoria { get; set; }
             public int idTipo_Categoria { get; set; }

        }

        public static List<Categoria> Categorias = new List<Categoria>();

        public static List<Tipo_Categoria> Tipos_Categoria = new List<Tipo_Categoria>();



    }
}

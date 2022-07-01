using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial
{
    public class Entidade
    {
        public int idEntidade { get; set; }
        public string nomeEntidade { get; set; }
        public string telefoneEntidade { get; set; }
        public string emailEntidade { get; set; }
        public string obsEntidade { get; set; }

        public static List<Entidade> Entidades = new List<Entidade>();
    }

    


    
}


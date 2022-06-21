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
        public string obsContatoEntidade { get; set; }
        public string obsEntidade { get; set; }

        public static List<Entidade> Entidades = new List<Entidade>();
    }

    public class Entidade_Classificacao
    {
        public int idEntidade { get; set; }
        public int idClassificacao { get; set; }
    }

    public class Classificacao
    {
        public int idClassificacao { get; set; }
        public string nomeClassificacao { get; set; }

        public static List<Classificacao> Classificacoes = new List<Classificacao>();
    }

    
}

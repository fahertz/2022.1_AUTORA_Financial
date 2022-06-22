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

    public class Entidade_Classificacao : ICloneable
    {
        public int idEntidade { get; set; }
        public int idClassificacao { get; set; }

        public object Clone()
        {
            return new Entidade_Classificacao() { idEntidade = this.idEntidade, idClassificacao = this.idClassificacao};
        }
        public static List<Entidade_Classificacao> Entidades_Classificacoes = new List<Entidade_Classificacao>();
    }

    public class Classificacao 
    {
        public int idClassificacao { get; set; }
        public string nomeClassificacao { get; set; }

        public static List<Classificacao> Classificacoes = new List<Classificacao>();
    }

    
}


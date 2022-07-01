using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial
{
    public class Entidade_Classificacao : ICloneable
    {
        public int idEntidade { get; set; }
        public int idClassificacao { get; set; }

        public object Clone()
        {
            return new Entidade_Classificacao() { idEntidade = this.idEntidade, idClassificacao = this.idClassificacao };
        }
        public static List<Entidade_Classificacao> Entidades_Classificacoes = new List<Entidade_Classificacao>();
    }

}

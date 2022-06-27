using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial
{
    public class Local
    {
        public int idLocal { get; set; }
        public string nameLocal { get; set; }
        
        public double valorLocal { get; set; }

        public string observacaoLocal { get; set; }

        public double incremetar_Saldo(double valor)
        {
            valorLocal += valor;
            return valorLocal;
        }

        public double decrementar_Saldo(double valor)
        {
            valorLocal -= valor;
            return valorLocal;
        }

        public static List<Local> Locais = new List<Local>();
    }
}

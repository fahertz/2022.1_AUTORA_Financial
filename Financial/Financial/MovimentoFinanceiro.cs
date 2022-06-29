using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial
{
    public class MovimentoFinanceiro
    {
        public int idEntidade { get; set; }
        public int idLocal { get; set; }
        public int idCategoria { get; set; }
        public int numParcelas { get; set; }
        public double valorTransacao { get; set; }
        public string formaMovimento { get; set; }
        public string obsMovimento { get; set; }        
        public DateTime dataMovimento { get; set; }

        
        
        //Aberto - A / Fechado - F
        public char statusMovimento { get; set; }

        public virtual object Clone()
        {
            return new MovimentoFinanceiro() { idEntidade = this.idEntidade
                                             , idLocal = this.idLocal
                                             , idCategoria = this.idCategoria
                                             , numParcelas = this.numParcelas
                                             , valorTransacao = this.valorTransacao
                                             , formaMovimento = this.formaMovimento
                                             , obsMovimento = this.obsMovimento
                                             , dataMovimento = this.dataMovimento                                             
            };
        }        
    }

    public class EntradaFinanceira : MovimentoFinanceiro
    {
        // Entrada - Saida
        private string tipoMovimento = "Entrada";

        public override object Clone()
        {
            return new EntradaFinanceira()
            {
                  idEntidade = this.idEntidade               
                , idLocal = this.idLocal               
                , idCategoria = this.idCategoria               
                , numParcelas = this.numParcelas               
                , valorTransacao = this.valorTransacao               
                , formaMovimento = this.formaMovimento               
                , obsMovimento = this.obsMovimento               
                , dataMovimento = this.dataMovimento              
                , tipoMovimento = this.tipoMovimento
            };
        }
        public static List<EntradaFinanceira> Entradas_Financeiras = new List<EntradaFinanceira>();
    }
    public class SaidaFinanceira : MovimentoFinanceiro
    {
        // Entrada - Saida
        private string tipoMovimento = "Saída";
        public override object Clone()
        {
            return new SaidaFinanceira()
            {
                 idEntidade = this.idEntidade                                             
               , idLocal = this.idLocal                                             
               , idCategoria = this.idCategoria                                             
               , numParcelas = this.numParcelas                                             
               , valorTransacao = this.valorTransacao                                             
               , formaMovimento = this.formaMovimento                
               , obsMovimento = this.obsMovimento
               , dataMovimento = this.dataMovimento
               , tipoMovimento = this.tipoMovimento
            };
        }

        public static List<SaidaFinanceira> Saidas_Financeiras = new List<SaidaFinanceira>();
    }

    
}

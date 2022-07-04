using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.EntradaFinanceira;
namespace Financial
{



    public class MovimentoFinanceiro
    {


        public static Mensagem mm = new Mensagem();

        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        public static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        public static string folder_Operacoes = "\\" + "OPERACOES";                                                    //Nome do diretório das operações        
        //public string nome_Arquivo_Entradas = "\\OPE_ENTRADA.json";                                           //Nome do arquivo de entradas        


        public int idOperacao { get; set; }
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
            return new MovimentoFinanceiro() { 
                                                idOperacao = this.idOperacao
                                             , idEntidade = this.idEntidade
                                             , idLocal = this.idLocal
                                             , idCategoria = this.idCategoria
                                             , numParcelas = this.numParcelas
                                             , valorTransacao = this.valorTransacao
                                             , formaMovimento = this.formaMovimento
                                             , obsMovimento = this.obsMovimento
                                             , dataMovimento = this.dataMovimento   
                                             , statusMovimento = this.statusMovimento
            };
        }        


        public static int obterUltimoCodigo(object _obj)
        {

            if (_obj is EntradaFinanceira) 
            {
                if (Entradas_Financeiras.Count > 0)
                    return Entradas_Financeiras[Entradas_Financeiras.Count - 1].idLocal;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }


    }

    public class EntradaFinanceira : MovimentoFinanceiro
    {
        //Nome do arquivo
        private static string nome_Arquivo = "\\OPE_ENTRADA.json";

        // Entrada - Saida
        public string tipoMovimento { get; set; }
        
        public override object Clone()
        {
            return new EntradaFinanceira()
            {
                  idOperacao = this.idOperacao
                , idEntidade = this.idEntidade               
                , idLocal = this.idLocal               
                , idCategoria = this.idCategoria               
                , numParcelas = this.numParcelas               
                , valorTransacao = this.valorTransacao               
                , formaMovimento = this.formaMovimento               
                , obsMovimento = this.obsMovimento               
                , dataMovimento = this.dataMovimento              
                , tipoMovimento = this.tipoMovimento
                , statusMovimento = this.statusMovimento
            };
        }

        public static void salvar()
        {                     
            try
            {
                StreamWriter writer_Entrada = new StreamWriter(wpath + folder_Operacoes + nome_Arquivo);
                writer_Entrada.Close();                                
                if (Entradas_Financeiras.Count > 0)
                {                    
                    File.WriteAllText(wpath +folder_Operacoes + nome_Arquivo , JsonConvert.SerializeObject(Entradas_Financeiras, Formatting.Indented), Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                mm.Message = "Erro de leitura: " + ex.Message.ToString() + ", por favor acione o suporte.";
                mm.Tittle = "Erro";
                mm.Buttons = MessageBoxButtons.OK;
                mm.Icon = MessageBoxIcon.Error;
                mm.exibirMensagem();
            }

        }


        public static void adicionar(EntradaFinanceira entrada)
        {            
            Entradas_Financeiras.Add(entrada);            
            salvar();
        }






        public static void carregar(Object _obj)
        {
            if (_obj is DataGridView)
            {
                DataGridView _dgv = (DataGridView)_obj;
                _dgv.Rows.Clear();
                _dgv.Columns.Clear();
                _dgv.Columns.Add("Id","Id");

                var select = from item in Entradas_Financeiras
                             select new { item.idOperacao };


            }    
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

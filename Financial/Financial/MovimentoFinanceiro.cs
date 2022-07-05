using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.EntradaFinanceira;
using static Financial.Entidade;
using static Financial.Categoria_Financeira.Categoria;

namespace Financial
{



    public class MovimentoFinanceiro
    {


        public static Mensagem mm = new Mensagem();

        

        //Instância pública
        public static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); 
        public static string folder_Operacoes = "\\" + "OPERACOES";                                          
        

        //Instância Privada

        //Id da operação
        public int idOperacao { get; set; }
        
        //Relações
        public int idEntidade { get; set; }
        public int idLocal { get; set; }
        public int idCategoria { get; set; }

        //Parcelas
        public int numParcela { get; set; }
        
        //Valores
        public double valorTransacao { get; set; }

        //Strings
        public string formaMovimento { get; set; }
        public string obsMovimento { get; set; }        
        public DateTime dataMovimento { get; set; }

        // Entrada - Saida
        public string tipoMovimento { get; set; }
                
        //Aberto - A / Fechado - F
        public char statusMovimento { get; set; }

        public virtual object Clone()
        {
            return new MovimentoFinanceiro() { 
                                               idOperacao = this.idOperacao
                                             , idEntidade = this.idEntidade
                                             , idLocal = this.idLocal
                                             , idCategoria = this.idCategoria
                                             , numParcela = this.numParcela
                                             , valorTransacao = this.valorTransacao
                                             , formaMovimento = this.formaMovimento
                                             , obsMovimento = this.obsMovimento
                                             , tipoMovimento = this.tipoMovimento
                                             , dataMovimento = this.dataMovimento   
                                             , statusMovimento = this.statusMovimento
            };
        }        


        public static int obterUltimoCodigo(object _obj)
        {

            if (_obj is EntradaFinanceira)
            {
                if (Entradas_Financeiras.Count > 0)
                {
                    
                    return Entradas_Financeiras[Entradas_Financeiras.Count - 1].idOperacao;
                }
                else
                    return 0;
            }
            else return 0;
        }


    }

    public class EntradaFinanceira : MovimentoFinanceiro
    {
        //Nome do arquivo
        public static string nome_Arquivo = "\\OPE_ENTRADA.json";


        public virtual object Clone()
        {
            return new EntradaFinanceira()
            {
                idOperacao = this.idOperacao,
                idEntidade = this.idEntidade,
                idLocal = this.idLocal,
                idCategoria = this.idCategoria,
                numParcela = this.numParcela,
                valorTransacao = this.valorTransacao,
                formaMovimento = this.formaMovimento,
                obsMovimento = this.obsMovimento,
                tipoMovimento = this.tipoMovimento,
                dataMovimento = this.dataMovimento,
                statusMovimento = this.statusMovimento
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

        public static void editar(EntradaFinanceira entrada)
        {
            foreach (var editar in Entradas_Financeiras)
            {
                if (editar.idOperacao == entrada.idOperacao)
                {
                editar.idEntidade = entrada.idEntidade;
                editar.idLocal         = entrada.idLocal        ;
                editar.idCategoria     = entrada.idCategoria    ;
                editar.numParcela      = entrada.numParcela     ;
                editar.valorTransacao  = entrada.valorTransacao ;
                editar.formaMovimento  = entrada.formaMovimento ;
                editar.obsMovimento    = entrada.obsMovimento   ;
                editar.tipoMovimento   = entrada.tipoMovimento  ;
                editar.dataMovimento   = entrada.dataMovimento  ;
                editar.statusMovimento = entrada.statusMovimento;
                }
            }
            salvar();
        }

        public static void deletar(int idOperacao)
        {
            foreach (var excluir in Entradas_Financeiras)
            {
                if (excluir.idOperacao == idOperacao) 
                {
                    Entradas_Financeiras.Remove(excluir);
                    break;
                }
            }
            if (Entradas_Financeiras.Count > 0)
            {
                salvar();
            }
            else
            {
                File.Delete(wpath + folder_Operacoes + nome_Arquivo);
            }
        }

        





        public static void carregar(Object _obj)
        {
            if (_obj is DataGridView)
            {
                DataGridView _dgv = (DataGridView)_obj;
                _dgv.Rows.Clear();
                _dgv.Columns.Clear();
                _dgv.Columns.Add("idOperacao", "ID");
                _dgv.Columns.Add("descEntidade", "Entidade");
                _dgv.Columns.Add("descCategoria", "Categoria");
                _dgv.Columns.Add("dataMovimento", "Data");
                _dgv.Columns.Add("valorTransacao", "Valor");
                _dgv.Columns.Add("status", "Status");


                var select = from entradas in Entradas_Financeiras
                             join entidade in Entidades
                             on entradas.idEntidade equals entidade.idEntidade
                             join categoria in Categorias
                             on entradas.idCategoria equals categoria.idCategoria                                                         
                             select new { entradas.idOperacao, entidade.nomeEntidade, categoria.descCategoria, entradas.dataMovimento, entradas.valorTransacao, entradas.statusMovimento};

                



                if (Entradas_Financeiras.Count > 0)
                {
                    foreach (var item in select)
                    {
                        _dgv.Rows.Add(item.idOperacao, item.nomeEntidade, item.descCategoria, item.dataMovimento.ToShortDateString(), item.valorTransacao.ToString("C"),item.statusMovimento);
                    }
                }


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
               , numParcela = this.numParcela                                             
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

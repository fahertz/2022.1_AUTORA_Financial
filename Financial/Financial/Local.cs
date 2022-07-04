using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial
{
    public class Local
    {
        
        static Mensagem mm = new Mensagem();       
        
        //Instância de atributos privados
        private static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        private static string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        private static string nome_Arquivo = "\\CAD_LOCAL.json";                                              //Nome do arquivo

        //Instância de atributos públicos
        public int idLocal { get; set; }
        public string nameLocal { get; set; }        
        public double valorLocal { get; set; }
        public string observacaoLocal { get; set; }

        //Lista estátca de dados
        public static List<Local> Locais = new List<Local>();

        //Métodos de resgate
        public static int obterUltimoCodigo()
        {
            if (Locais.Count > 0)
                return Locais[Locais.Count - 1].idLocal + 1;
            else
                return 1;
        }

        //Métodos de manipulação
        private static void salvar()
        {      
            try
            {
                //Abre o Writer para escrever o arquivo no caminho especificado
                StreamWriter writer_Locais = new StreamWriter(wpath + folder + nome_Arquivo);
                writer_Locais.Close();

                //Se a quantidade de item não estiver vazia, ele cria o arquivo, a trava existe para que não haja brechas para gerar um arquivo vazio
                if (Locais.Count > 0)                
                    File.WriteAllText(wpath + folder + nome_Arquivo, JsonConvert.SerializeObject(Locais, Formatting.Indented), Encoding.UTF8);                
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
        public static void adicionar(dynamic codigo, dynamic descricao, dynamic valor, dynamic observacao)
        {
            Locais.Add(new Local { idLocal = Convert.ToInt32(codigo), nameLocal = descricao, valorLocal = Convert.ToDouble(valor), observacaoLocal = observacao });
            salvar();
        }
        public static void editar(dynamic codigo, dynamic descricao, dynamic valor, dynamic observacao)
        {
            foreach (var local in Locais)
            {
                if (local.idLocal == Convert.ToInt32(codigo))
                {
                    local.nameLocal = descricao;
                    local.valorLocal = Convert.ToDouble(valor);
                    local.observacaoLocal = observacao;
                    break;
                }
            }
            salvar();
        }
        public static void deletar(dynamic codigo)
        {           
            foreach (var local in Locais)
            {
                if (local.idLocal == Convert.ToInt32(codigo))
                {
                    Locais.Remove(local);
                    break;
                }
            }
            if (Locais.Count > 0)
            {
                salvar();
            }
            else
            {
                File.Delete(wpath + folder + nome_Arquivo);
            }
        }

        //Métodos de operação
        public static void incremetar_Saldo(dynamic codigo, dynamic valor)
        {            
             foreach (var local in Locais)
                {
                if (local.idLocal == Convert.ToInt32(codigo))
                {
                    local.valorLocal += Convert.ToDouble(valor);
                }
            }
            Local.salvar();
        }
        public static void decrementar_Saldo(dynamic codigo, dynamic valor)
        {
            foreach (var local in Locais)
            {
                if (local.idLocal == Convert.ToInt32(codigo))
                {
                    local.valorLocal -= Convert.ToDouble(valor);
                }
            }
            Local.salvar();
        }

        //Métodos de visualização
        private static void configurarGrid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Local", "Cód. Local");
                _dgv.Columns.Add("Des_Local", "Local");
            });
        }
        public static void carregar(Object _obj)
        {
            if (_obj is DataGridView)
            {
                DataGridView _dgv = (DataGridView)_obj;

                _dgv.Columns.Clear();
                _dgv.Rows.Clear();
                configurarGrid(_dgv);
                
                var query_Local = from local in Locais
                            select new
                            {
                                 local.idLocal
                                ,local.nameLocal
                                ,local.valorLocal
                                ,local.observacaoLocal
                            };


                foreach (var item in query_Local)
                {
                    _dgv.Invoke((MethodInvoker)delegate
                    {
                        _dgv.Rows.Add(item.idLocal, item.nameLocal);
                    });
                }
            }
        }
    }
}

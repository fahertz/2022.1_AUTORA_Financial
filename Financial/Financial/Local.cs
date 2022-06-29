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

        private static Mensagem mm = new Mensagem();
        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        private static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        private static string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        private static string nome_Arquivo = "\\CAD_LOCAL.json";                                     //Nome do arquivo

        public int idLocal { get; set; }
        public string nameLocal { get; set; }        
        public double valorLocal { get; set; }
        public string observacaoLocal { get; set; }


        //Salvar categoria
        private static void salvar_Local()
        {
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;            
            try
            {
                StreamWriter writer_Locais = new StreamWriter(_folder + nome_Arquivo);
                writer_Locais.Close();
                if (Locais.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Locais, Formatting.Indented), Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                Local.mm.Message = "Erro de leitura: " + ex.Message.ToString() + ", por favor acione o suporte.";
                Local.mm.Tittle = "Erro";
                Local.mm.Buttons = MessageBoxButtons.OK;
                Local.mm.Icon = MessageBoxIcon.Error;
                Local.mm.exibirMensagem();                
            }            
        }

        //Incrementar saldo armazenado
        public static void incremetar_Saldo(dynamic codigo, dynamic valor)
        {            
             foreach (var local in Locais)
                {
                if (local.idLocal == Convert.ToInt32(codigo))
                {
                    local.valorLocal += Convert.ToDouble(valor);
                }
            }
            Local.salvar_Local();
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
            Local.salvar_Local();
        }

        public static void adicionar_Local(dynamic codigo, dynamic descricao, dynamic valor, dynamic observacao)
        {            
                Locais.Add(new Local { idLocal = Convert.ToInt32(codigo), nameLocal = descricao, valorLocal = Convert.ToDouble(valor), observacaoLocal = observacao });
                salvar_Local();            
        }


        public static void editar_Local(dynamic codigo, dynamic descricao, dynamic valor, dynamic observacao)
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
            salvar_Local();
        }

        public static void deletar_Local(dynamic codigo)
        {
            string _folder = wpath + folder;
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
                salvar_Local();
            }
            else
            {
                File.Delete(folder+nome_Arquivo);
            }
        }

        //Carrega o último código adicionado
        public static int getLastCode()
        {
            if (Locais.Count > 0)
                return Locais[Locais.Count - 1].idLocal + 1;
            else
                return 1;
        }

        public static List<Local> Locais = new List<Local>();
    }
}

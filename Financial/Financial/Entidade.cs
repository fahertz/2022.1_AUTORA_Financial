using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Entidade_Classificacao;
using static Financial.Classificacao;

namespace Financial
{
    public class Entidade
    {

        static Mensagem mm = new Mensagem();
        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        static string folder = "\\" + "CADASTROS";                                                   //Nome do diretório dos cadastros
        static string nome_Arquivo = "\\CAD_ENTIDADE.json";                                           //Nome do arquivo
        



        public int idEntidade { get; set; }
        public string nomeEntidade { get; set; }
        public string telefoneEntidade { get; set; }
        public string emailEntidade { get; set; }
        public string obsEntidade { get; set; }

        public static List<Entidade> Entidades = new List<Entidade>();

        public static int retornarUltimoCodigo()
        {
            if (Entidades.Count > 0)
                return Entidades[Entidades.Count - 1].idEntidade + 1;
            else
                return 1;
        }

        private static void salvar()
        {            
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;
            try
            {
                StreamWriter writer_Entidade = new StreamWriter(_folder + nome_Arquivo);
                writer_Entidade.Close();
                if (Entidades.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Entidades, Formatting.Indented), Encoding.UTF8);
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

        public static void adicionar(dynamic Codigo, dynamic Descricao,dynamic Telefone, dynamic Email, dynamic Obs)
        {
            Entidades.Add(new Entidade { idEntidade = Convert.ToInt32(Codigo) 
                                        ,nomeEntidade = Descricao
                                        ,telefoneEntidade = Telefone
                                        ,emailEntidade = Email
                                        ,obsEntidade = Obs
            });
            salvar();
        }

        public static void editar(dynamic Codigo, dynamic Descricao, dynamic Telefone, dynamic Email, dynamic Obs)
        {
            foreach (var item in Entidades)
            {
                if (item.idEntidade == Convert.ToInt32(Codigo))
                {
                    item.nomeEntidade = Descricao;
                    item.telefoneEntidade = Telefone;
                    item.emailEntidade = Email;
                    item.obsEntidade = Obs;
                    break;
                }
            }
            salvar();
        }

        public static void deletar(dynamic Codigo)
        {
            foreach (var item in Entidades)
            {
                if (item.idEntidade == Convert.ToInt32(Codigo))
                {
                    Entidades.Remove(item);
                    break;
                }
            }
            if (Entidades.Count > 0)
            {
                salvar();
            }
            else
            {
                File.Delete(wpath + folder + nome_Arquivo);
            }
        }


        //Configuração da Grid
        private static void configurarGrid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Entidade", "Cód. Entidade");
                _dgv.Columns.Add("Des_Entidade", "Entidade");
                
            });
        }

        public static void carregar(DataGridView _dgv)
        {
            _dgv.Columns.Clear();
            _dgv.Rows.Clear();
            configurarGrid(_dgv);
            var query = from entidade in Entidades                      
                        select new
                        {
                             entidade.idEntidade
                            ,entidade.nomeEntidade
                            ,entidade.telefoneEntidade
                            ,entidade.emailEntidade                            
                            ,entidade.obsEntidade
                            
                        };


            foreach (var item in query)
            {
                _dgv.Invoke((MethodInvoker)delegate
                {
                    _dgv.Rows.Add(item.idEntidade, item.nomeEntidade);
                });
            }

        }
    }

    


    
}


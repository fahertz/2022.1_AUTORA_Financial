using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Entidade_Classificacao;
namespace Financial
{

    public class Classificacao
    {

        //Instância
        //Classe para emissão de mensagens de forma simplificada
        static Mensagem mm = new Mensagem();

        ////Armazenamento utilizado pela tela        
        //Pega a raiz bin para salvar o arquivo produtos
        static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        static string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        static string nome_Arquivo = "\\CAD_CLASSIFICACAO.json";                                     //Nome do arquivo


        public int idClassificacao { get; set; }
        public string nomeClassificacao { get; set; }

        public static List<Classificacao> Classificacoes = new List<Classificacao>();


        public static int retornarUltimoCodigo()
        {
            if (Classificacoes.Count > 0)
                return Classificacoes[Classificacoes.Count - 1].idClassificacao + 1;
            else
                return 1;
        }

        private static void salvar()
        {
            
            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;
            try
            {
                StreamWriter writer_TipoCategoria = new StreamWriter(_folder + nome_Arquivo);
                writer_TipoCategoria.Close();
                if (Classificacoes.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Classificacoes, Formatting.Indented), Encoding.UTF8);
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

        public static void adicionar(dynamic Codigo, dynamic Descricao)
        {
            Classificacoes.Add(new Classificacao { idClassificacao = Convert.ToInt32(Codigo), nomeClassificacao = Descricao });
            salvar();
        }

        public static void editar(dynamic Codigo, dynamic Descricao)
        {
            foreach (var item in Classificacoes)
            {
                if (item.idClassificacao == Convert.ToInt32(Codigo))
                {
                    item.nomeClassificacao = Descricao;
                    break;
                }
            }
            salvar();
        }

        public static int deletar(dynamic Codigo)
        {

            foreach (var item in Entidades_Classificacoes)
            {
                if (item.idClassificacao == Convert.ToInt32(Codigo))
                    return 0;
            }

            foreach (var item in Classificacoes)
            {
                if (item.idClassificacao == Convert.ToInt32(Codigo))
                {
                    Classificacoes.Remove(item);
                    break;
                }
            }

            if (Classificacoes.Count > 0)
            {
                salvar();
                return 1;
            }
            else
            {
                File.Delete(folder + nome_Arquivo);
                return 1;
            }
        }

        //Configuração da Grid
        private static void configurarGrid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Classificacao", "Cod. Classificação");
                _dgv.Columns.Add("Des_Classificacao", "Classificação");
            });
        }

        public static void carregar(DataGridView _dgv)
        {
            _dgv.Columns.Clear();
            _dgv.Rows.Clear();
            configurarGrid(_dgv);
            var query = from classificacoes in Classificacoes
                        select new
                        {
                            classificacoes.idClassificacao
                            ,
                            classificacoes.nomeClassificacao
                        };


            foreach (var item in query)
            {
                _dgv.Invoke((MethodInvoker)delegate
                {
                    _dgv.Rows.Add(item.idClassificacao, item.nomeClassificacao);
                });
            }

        }
        }


    }
}

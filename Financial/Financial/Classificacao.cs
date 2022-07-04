using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Entidade_Classificacao;
namespace Financial
{

    public class Classificacao
    {

  
        static Mensagem mm = new Mensagem();

        //Instância privada
        public static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        public static string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        public static string nome_Arquivo = "\\CAD_CLASSIFICACAO.json";                                     //Nome do arquivo

        //Instância pública
        public int idClassificacao { get; set; }
        public string nomeClassificacao { get; set; }

        //Lista de dados estáticos
        public static List<Classificacao> Classificacoes = new List<Classificacao>();

        //Métodos de resgate
        public static int obterUltimoCodigo()
        {
            if (Classificacoes.Count > 0)
                return Classificacoes[Classificacoes.Count - 1].idClassificacao + 1;
            else
                return 1;
        }

        //Métodos de Manipulação
        private static void salvar()
        {
            try
            {
                StreamWriter writer_TipoCategoria = new StreamWriter(wpath +folder + nome_Arquivo);
                writer_TipoCategoria.Close();
                if (Classificacoes.Count > 0)                
                    File.WriteAllText(wpath + folder + nome_Arquivo, JsonConvert.SerializeObject(Classificacoes, Formatting.Indented), Encoding.UTF8);                
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

        //Métodos de visualização
        private static void configurarGrid(DataGridView _dgv)
        {
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Cod_Classificacao", "Cod. Classificação");
                _dgv.Columns.Add("Des_Classificacao", "Classificação");
            });
        }
        public static void carregar(Object _obj, dynamic CodigoEntidade = null)
        {

            dynamic query = null;

            if (_obj is DataGridView) 
            {
                DataGridView _dgv = (DataGridView)_obj;
                _dgv.Columns.Clear();
                _dgv.Rows.Clear();
                configurarGrid(_dgv);          
                

                if (CodigoEntidade != null)
                {
                    query = from classificacao in Classificacoes
                            join entidade_classificacao in Entidades_Classificacoes
                            on new
                            {
                                classificacao.idClassificacao
                            }
                            equals new
                            {
                                entidade_classificacao.idClassificacao
                            }
                            where Convert.ToInt32(CodigoEntidade) == entidade_classificacao.idEntidade
                            select new
                            {
                                classificacao.idClassificacao
                                ,
                                classificacao.nomeClassificacao
                            };
                }
                else
                {
                     query = from classificacoes in Classificacoes
                                select new
                                {
                                    classificacoes.idClassificacao
                                    ,classificacoes.nomeClassificacao
                                };
                }

                foreach (var item in query)
                {
                    _dgv.Invoke((MethodInvoker)delegate
                    {
                        _dgv.Rows.Add(item.idClassificacao, item.nomeClassificacao);
                    });
                }
            }

            else if (_obj is ComboBox)
            {
                ComboBox _cbx = (ComboBox)_obj;
                _cbx.Items.Clear();
                _cbx.Invoke((MethodInvoker)delegate
                {
                    foreach (var ent in Classificacoes)
                    {
                        if (ent != null)
                            _cbx.Items.Add(ent.idClassificacao + " | " + ent.nomeClassificacao);
                    }
                });
            }
            else if (_obj is List<int>)
            {
                List<int> _list = (List<int>)_obj;
                _list.Clear();
                if (Convert.ToInt32(CodigoEntidade) != null) 
                {
                   

                    query = from classificacao in Classificacoes
                            join entidade_classificacao in Entidades_Classificacoes
                            on new
                            {
                                classificacao.idClassificacao
                            }
                            equals new
                            {
                                entidade_classificacao.idClassificacao
                            }
                            where Convert.ToInt32(CodigoEntidade) == entidade_classificacao.idEntidade
                            select new
                            {
                                classificacao.idClassificacao
                                ,
                                classificacao.nomeClassificacao
                            };



                    foreach (var ent in Classificacoes)
                    {
                        _list.Add(ent.idClassificacao);
                    }
                }
                else
                {
                    foreach (var ent in Classificacoes)
                        _list.Add((int)ent.idClassificacao);
                }
                
            }
        }

    }
}

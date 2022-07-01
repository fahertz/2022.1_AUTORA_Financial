using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Financial.Classificacao;

namespace Financial
{
    public class Entidade_Classificacao : ICloneable
    {

        static Mensagem mm = new Mensagem();
        ////////////////Bloco para armazenar cadastros em geral
        //Pega a raiz bin para salvar o arquivo produtos
        static string wpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString(); //Pega o caminho BIN da aplicação
        static string folder = "\\" + "CADASTROS";                                                    //Nome do diretório dos cadastros
        static string nome_Arquivo = "\\CAD_CLASSIFICACAO_ENTIDADE.json";                             //Nome do arquivo

        public int idEntidade { get; set; }
        public int idClassificacao { get; set; }
        
        public static List<Entidade_Classificacao> Entidades_Classificacoes = new List<Entidade_Classificacao>();

        public object Clone()
        {
            return new Entidade_Classificacao() { idEntidade = this.idEntidade, idClassificacao = this.idClassificacao };
        }


        private static void salvar()
        {

            //Caminho da aplicação + nome da pasta
            string _folder = wpath + folder;
            try
            {
                StreamWriter writer_EntidadeClassificacao = new StreamWriter(_folder + nome_Arquivo);
                writer_EntidadeClassificacao.Close();
                if (Entidades_Classificacoes.Count > 0)
                {
                    File.WriteAllText(_folder + nome_Arquivo, JsonConvert.SerializeObject(Entidades_Classificacoes, Formatting.Indented), Encoding.UTF8);
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

        public static void adicionar(dynamic Codigo_Entidade, dynamic Codigo_Classificacao)
        {
            Entidades_Classificacoes.Add(new Entidade_Classificacao { idEntidade =  Convert.ToInt32(Codigo_Entidade), idClassificacao = Convert.ToInt32(Codigo_Classificacao) });
            salvar();
        }


        public static void editar (dynamic Codigo_Entidade, object _obj)
        {
         
            if (_obj is DataGridView)
            {
                DataGridView _dgv = (DataGridView)_obj;
                deletar(Codigo_Entidade);

                foreach (DataGridViewRow _row in _dgv.Rows)
                {
                    adicionar(Codigo_Entidade,_row.Cells[0].Value);
                }
            }


        }

        


        public static int deletar(dynamic Codigo_Entidade, dynamic Codigo_Classificacao = null)
        {
            if (Codigo_Classificacao is null) 
            {
                foreach (var item in Entidades_Classificacoes)
                {
                    if (item.idEntidade == Convert.ToInt32(Codigo_Entidade) && item.idClassificacao == Convert.ToInt32(Codigo_Classificacao))
                    {
                        Entidades_Classificacoes.Remove(item);
                    }
                }

                if (Entidades_Classificacoes.Count > 0)
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
            else
            {
                foreach (var item in Entidades_Classificacoes)
                {
                    if (item.idEntidade == Convert.ToInt32(Codigo_Entidade))
                    {
                        Entidades_Classificacoes.Remove(item);
                    }
                }

                if (Entidades_Classificacoes.Count > 0)
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

        }

        public static List<Classificacao> consultarClassificacao(int codigo)
        {
            List<Classificacao> listCLassificacoes = new List<Classificacao>();

            var selectClassificacoesDaEntidade = from classificacao in Classificacoes
                                                 join entidade_classificacao in Entidades_Classificacoes
                                                 on new
                                                 {
                                                     classificacao.idClassificacao
                                                 }
                                                 equals new
                                                 {
                                                     entidade_classificacao.idClassificacao
                                                 }
                                                 where Convert.ToInt32(codigo) == entidade_classificacao.idEntidade
                                                 select new
                                                 {
                                                     classificacao.idClassificacao
                                                     ,
                                                     classificacao.nomeClassificacao
                                                 };

            foreach (var item in selectClassificacoesDaEntidade)
            {
                listCLassificacoes.Add(new Classificacao { idClassificacao = item.idClassificacao, nomeClassificacao = item.nomeClassificacao });
            }

            return listCLassificacoes;
        }



    }

}

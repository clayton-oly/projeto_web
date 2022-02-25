using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Relatorio
    {
        ///<summary>
        ///Diretório onde irá salvar o arquivo
        ///</summary>
        ///
        public string Diretorio { get; set; }

        ///<summary>
        ///Nome arquivo a ser salvo
        ///</summary>
        ///
        public string NomeArquivo { get; set; }

        ///<summary>
        ///Grid onde contém as informações
        /// </summary>
        /// 
        public DataGridView Grid { get; set; }




        public void GerarHtml()
        {
            //objeto de construção de string
            StringBuilder sb = new StringBuilder();

            //criação de tabela
            sb.AppendLine("<table border= '1'>");

            // Criando cabeçalho
            sb.AppendLine("<tr>");
            foreach (DataGridViewColumn item in Grid.Columns)
            {
                sb.AppendLine("<td>");
                sb.AppendLine(item.HeaderText);
                sb.AppendLine("</td>");
            }

            sb.AppendLine("</tr>"); ;
            //Fim do cabeçalho

            //Criando as linhas
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                sb.AppendLine("<tr>");

                //Criando cada celula
                foreach (DataGridViewCell celula in linha.Cells)
                {
                    sb.AppendLine("<td>");
                    sb.AppendLine(celula.Value.ToString());
                    sb.AppendLine("</td>");
                }

                //fim das celulas

                sb.AppendLine("</tr>");

            }
            //fim de linhas


            sb.AppendLine("<tr>");

            sb.AppendLine("<td colspan = '5'>");
            sb.AppendLine("Relatório gerado " + DateTime.Now);
            sb.AppendLine("</td>");

            sb.AppendLine("</tr>");


            //Encerrando cabeçalho
            sb.AppendLine("</table>");

            //Definindo nome e local do arquivo
            string arquivo = Path.Combine(Diretorio, NomeArquivo);

            //Escrevendo o arquivo no diretório
            File.WriteAllText(arquivo, sb.ToString(), Encoding.Default);
        }

    }

}

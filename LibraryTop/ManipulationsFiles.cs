using System;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace LibraryTop
{
    /// <summary>
    /// Essa classe contém métodos e funções para a manipulação de arquivos.
    /// </summary>
    public class ManipulationsFiles
    {
        /// <summary>
        /// Verifica se o arquivo existe e deleta.
        /// </summary>
        /// <param name="arquivo">Caminho completo do arquivo.</param>
        /// <example>C:\Pasta_Do_Arquivo\Nome_Do_Arquivo.pdf</example>
        /// <returns>Retorna uma mensagem de confirmação de exclusão do arquivo.</returns>
        /// <exception cref="Exception">Retorna uma exceção caso aconteça algum erro ao tentar excluir o arquivo.</exception>
        public string DeletaArquivo(string arquivo)
        {
            try
            {
                if (ExiteArquivo(arquivo))
                    File.Delete(arquivo);

                return $"O arquivo {arquivo} foi deletado com sucesso.";
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar excluir o arquivo. Erro: {ex.Message}");
            }

        }

        /// <summary>
        /// Procura por um arquivo.
        /// </summary>
        /// <param name="arquivo">Caminho completo do arquivo.</param>
        /// <example>C:\Pasta_Do_Arquivo\Nome_Do_Arquivo.pdf</example>
        /// <returns>Retorna verdadeiro caso o arquivo exista ou falso se não existir.</returns>
        /// <exception cref="Exception">Retorna uma exceção caso aconteça algum erro ao tentar excluir o arquivo.</exception>
        public bool ExiteArquivo(string arquivo)
        {
            try
            {
                return File.Exists(arquivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when try search file. Message: {ex.Message}");
            }
        }

        /// <summary>
        /// Lê um arquivo Pdf.
        /// </summary>
        /// <param name="pdf">Caminho completo do arquivo.</param>
        /// <example>C:\Pasta_Do_Arquivo\Nome_Do_Arquivo.pdf</example>
        /// <returns>Retorna uma string contendo todo o contéudo do PDF.</returns>
        /// <exception cref="Exception">Retorna uma exceção caso aconteça algum erro ao tentar excluir o arquivo.</exception>
        public string LerPdf(string pdf)
        {
            StringBuilder text = new StringBuilder();

            try
            {
                using (PdfReader reader = new PdfReader(pdf))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }
                return text.ToString();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao tentar deletar o arquivo {pdf}. Mensagem do erro: {e.Message}");
            }
        }

        //public PDF LerPdf(string pdf)
        //{

        //}
    }
}

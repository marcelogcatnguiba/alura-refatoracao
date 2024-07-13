using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Readers.Result;

namespace Alura.Adopet.Console.Readers
{
    public class LeitorJSON(string caminhoDoArquivo) : ILeitor
    {
        private readonly string _caminho = caminhoDoArquivo;

        public ResultReader RealizarLeitura()
        {
            // Regra de leitura de JSON
            throw new NotImplementedException();
        }
    }
}
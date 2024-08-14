using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Leitores.Abstracao;

namespace Alura.Adopet.Console.Leitores.LeitoresClientes
{
    [LeitorAtribute(".csv")]
    public class LeitorCSVCliente(string caminhoDoArquivo) : LeitorCSV<Cliente>(caminhoDoArquivo)
    {
        public override Cliente RetornaClassFromLine(string line)
        {
            return line.RetornaClienteString();
        }
    }
}
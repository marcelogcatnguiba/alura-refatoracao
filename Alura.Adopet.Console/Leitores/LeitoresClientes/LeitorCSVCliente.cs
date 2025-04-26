using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Abstracao;
using Alura.Adopet.Console.Leitores.Shared;

namespace Alura.Adopet.Console.Leitores.LeitoresClientes
{
    [LeitorAtribute(".csv")]
    public class LeitorCSVCliente(string caminhoDoArquivo) : LeitorCSV<Cliente>(caminhoDoArquivo)
    {

    }
}
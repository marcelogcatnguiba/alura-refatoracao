using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Abstracao;

namespace Alura.Adopet.Console.Leitores.LeitoresClientes
{
    [LeitorAtribute(".csv")]
    public class LeitorCSVCliente(string caminhoDoArquivo) : LeitorCSV<Cliente>(caminhoDoArquivo)
    {
        public override Cliente RetornaClassFromLine(string line)
        {
            string[] obj = line.Split(";");

            return new Cliente
            (
                id: Guid.Parse(obj[0]),
                nome: obj[1],
                email: obj[2]
            );
        }
    }
}
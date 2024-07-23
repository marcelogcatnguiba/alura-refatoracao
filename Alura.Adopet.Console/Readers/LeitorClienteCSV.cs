using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Readers.Abstracao;

namespace Alura.Adopet.Console.Readers
{
    public class LeitorClienteCSV(string caminhoDoArquivo) : LeitorCSV<Cliente>(caminhoDoArquivo)
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
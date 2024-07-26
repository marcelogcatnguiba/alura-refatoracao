using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Readers.Abstracao;

namespace Alura.Adopet.Console.Readers
{
    public class LeitorCSVPet(string caminhoDoArquivo) : LeitorCSV<Pet>(caminhoDoArquivo)
    {
        public override Pet RetornaClassFromLine(string line)
        {
           return line.RetornaPetString();
        }
    }
}
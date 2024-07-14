using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Extensions;

namespace Alura.Adopet.Console.Readers
{
    public class LeitorPetCSV(string caminhoDoArquivo) : LeitorCSV<Pet>(caminhoDoArquivo)
    {
        public override Pet RetornaClassFromLine(string line)
        {
           return line.RetornaPetString();
        }
    }
}
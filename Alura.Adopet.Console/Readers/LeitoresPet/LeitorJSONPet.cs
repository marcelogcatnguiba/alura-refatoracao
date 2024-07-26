using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Readers.Abstracao;

namespace Alura.Adopet.Console.Readers.LeitoresPet
{
    public class LeitorJSONPet(string caminho) : LeitorJSON<Pet>(caminho)
    {
        
    }
}
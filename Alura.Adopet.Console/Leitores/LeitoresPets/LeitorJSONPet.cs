using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Abstracao;
using Alura.Adopet.Console.Leitores.Shared;

namespace Alura.Adopet.Console.Leitores.LeitoresPets
{
    [LeitorAtribute(".json")]
    public class LeitorJSONPet(string caminho) : LeitorJSON<Pet>(caminho)
    {
        
    }
}
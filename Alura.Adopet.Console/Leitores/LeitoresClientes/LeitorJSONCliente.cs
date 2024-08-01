using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Abstracao;

namespace Alura.Adopet.Console.Leitores.LeitoresClientes
{
    [LeitorAtribute(".json")]
    public class LeitorJSONCliente(string caminho) : LeitorJSON<Cliente>(caminho)
    {
        
    }
}
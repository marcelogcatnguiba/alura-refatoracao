using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Readers.Abstracao;

namespace Alura.Adopet.Console.Readers.LeitoresCliente
{
    public class LeitorJSONCliente(string caminho) : LeitorJSON<Cliente>(caminho)
    {
        
    }
}
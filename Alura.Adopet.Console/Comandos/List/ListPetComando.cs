using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Comandos.List
{
    [ClassDocuments("list-pet", 
        "Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list")]
    public class ListPetComando(IApiService<Pet> service) : ListComando<Pet>(service)
    {
    }
}
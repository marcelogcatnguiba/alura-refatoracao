using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Comandos.Import
{
    [ClassDocuments("import-pet", "todo")]
    public class ImportPetComando(
        ILeitor<Pet> leitorArquivo, 
        IAPIService<Pet> httpClientPet) : ImportComando<Pet>(leitorArquivo, httpClientPet)
    {
    }
}
using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Comandos.Import
{
    [ClassDocuments("import-pet",
        "Realiza a importação em lote de um arquivos.\nDigite adopet import-cliente ou import-pet <arquivo>")]
    public class ImportPetComando(
        ILeitor<Pet> leitorArquivo, 
        IApiService<Pet> httpClientPet) : ImportComando<Pet>(leitorArquivo, httpClientPet)
    {
    }
}
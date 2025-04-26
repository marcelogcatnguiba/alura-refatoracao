using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Comandos.Import
{
    [ClassDocuments("import-cliente",
        "Realiza a importação em lote de um arquivos.\nDigite adopet import-cliente ou import-pet <arquivo>")]
    public class ImportClienteComando(
        ILeitor<Cliente> leitorArquivo, 
        IApiService<Cliente> httpClientPet) : ImportComando<Cliente>(leitorArquivo, httpClientPet)
    {
    }
}
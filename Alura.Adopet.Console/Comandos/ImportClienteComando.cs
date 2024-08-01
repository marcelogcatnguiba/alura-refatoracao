using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Comandos
{
    [ClassDocuments("import-cliente", "Comando para importar clientes")]
    public class ImportClienteComando(
        ILeitor<Cliente> leitorArquivo, IAPIService<Cliente> httpClientPet) 
        : ImportComando<Cliente>(leitorArquivo, httpClientPet)
    {
    }
}
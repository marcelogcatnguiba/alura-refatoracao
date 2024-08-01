using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.Interfaces;

namespace Alura.Adopet.Console.Comandos.Show
{
    [ClassDocuments("show-cliente", 
        "Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.")]
    public class ShowClienteComando(
        ILeitor<Cliente> leitorArquivo) : ShowComando<Cliente>(leitorArquivo)
    {
    }
}
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("help", "Comando que exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help")]
    public class HelpService : IComando
    {
        public async Task<Result> ExecutarComando(string[] args)
        {
            if (args.Length == 1) return await AjudaComandos();

            return await AjudaComandoEspecifico(args[1]);
        }
        private Task<Result> AjudaComandos()
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Lista de comandos.");
            System.Console.WriteLine("Import");
            System.Console.WriteLine("Help");
            System.Console.WriteLine("List");
            System.Console.WriteLine("Show");
            System.Console.WriteLine("Execute 'adopet help [comando]' para obter mais informações sobre um comando.");
            return Task.FromResult(Result.Ok());

        }
        private Task<Result> AjudaComandoEspecifico(string comando)
        {
            System.Console.WriteLine(ListaDeDocumentacao.GetDocumentacao(comando));
            return Task.FromResult(Result.Ok());
        }
    }
}

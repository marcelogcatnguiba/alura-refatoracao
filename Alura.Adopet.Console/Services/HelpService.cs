using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("help", "Comando que exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help")]
    public class HelpService : IComando
    {

        public HelpService()
        {

        }
        public async Task ExecutarComando(string[] args)
        {
            if (args.Length == 1)
                await AjudaComandos();

            await AjudaComandoEspecifico(args[1]);
        }
        private Task AjudaComandos()
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Lista de comandos.");
            System.Console.WriteLine("Import");
            System.Console.WriteLine("Help");
            System.Console.WriteLine("List");
            System.Console.WriteLine("Show");
            System.Console.WriteLine("Execute 'adopet help [comando]' para obter mais informações sobre um comando.");
            return Task.CompletedTask;

        }
        private Task AjudaComandoEspecifico(string comando)
        {
            System.Console.WriteLine(ListaDeDocumentacao.GetDocumentacao(comando));
            return Task.CompletedTask;
        }
    }
}

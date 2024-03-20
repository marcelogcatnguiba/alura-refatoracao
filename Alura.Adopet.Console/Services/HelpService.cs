using System.Reflection;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("help", "Comando que exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help")]
    public class HelpService : IComando
    {
        private readonly Dictionary<string, ClassDocuments> _dic = new Dictionary<string, ClassDocuments>();
        public HelpService()
        {
            _dic = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetCustomAttributes<ClassDocuments>().Any())
                .Select(x => x.GetCustomAttribute<ClassDocuments>()!)
                .ToDictionary(x => x.Comando);
        }
        public async Task ExecutarComando(string[] args)
        {
            if (args.Length == 1)
                await AjudaComandos();
            else
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
            if (_dic.ContainsKey(comando.ToLower()))
                System.Console.WriteLine(_dic[comando].Descricao);
            return Task.CompletedTask;
        }
    }
}

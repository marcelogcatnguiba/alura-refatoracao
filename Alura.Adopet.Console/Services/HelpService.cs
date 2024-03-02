using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("help", "Comando que exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help")]
    public class HelpService
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
        public void AjudaComandos()
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Lista de comandos.");
            System.Console.WriteLine("Import");
            System.Console.WriteLine("Help");
            System.Console.WriteLine("List");
            System.Console.WriteLine("Show");
            System.Console.WriteLine("Execute 'adopet help [comando]' para obter mais informações sobre um comando.");
        }
        public void AjudaComandoEspecifico(string comando)
        {
            if (_dic.ContainsKey(comando.ToLower()))
                System.Console.WriteLine(_dic[comando].Descricao);

            // switch (comando.ToLower())
            // {
            //     case "help":
            //         System.Console.WriteLine("Comando que exibe informações de ajuda dos comandos.");
            //         System.Console.WriteLine("Digite adopet help <comando> ou simplemente adopet help");
            //         break;

            //     case "import":
            //         System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            //         System.Console.WriteLine($"Digite adopet import <arquivo>");
            //         break;

            //     case "show":
            //         System.Console.WriteLine("Comando que exibe no terminal o conteúdo do arquivo importado.");
            //         System.Console.WriteLine($"Digite adopet show <arquivo>.");
            //         break;

            //     case "list":
            //         System.Console.WriteLine("Comando que exibe a lista de pets cadastrados no sistema");
            //         System.Console.WriteLine("Digite adopet list");
            //         break;
            // }
        }
    }
}

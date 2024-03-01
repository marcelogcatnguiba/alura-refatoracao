using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Services
{
    public class HelpService
    {
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

            switch (comando.ToLower())
            {
                case "help":
                    System.Console.WriteLine("Comando que exibe informações de ajuda dos comandos.");
                    System.Console.WriteLine("Digite adopet help <comando> ou simplemente adopet help");
                    break;

                case "import":
                    System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                    System.Console.WriteLine($"Digite adopet import <arquivo>");
                    break;

                case "show":
                    System.Console.WriteLine("Comando que exibe no terminal o conteúdo do arquivo importado.");
                    System.Console.WriteLine($"Digite adopet show <arquivo>.");
                    break;

                case "list":
                    System.Console.WriteLine("Comando que exibe a lista de pets cadastrados no sistema");
                    System.Console.WriteLine("Digite adopet list");
                    break;
            }
        }
    }
}

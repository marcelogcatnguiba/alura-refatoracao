using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.SuccessResult;
using FluentResults;

namespace Alura.Adopet.Console.UI
{
    public static class ConsoleUI
    {
        public static void ExibeResultado(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            try
            {
                if(result.IsFailed)
                {
                    ExibirFalha(result);
                    return;
                }

                ExibirSucesso(result);
            }
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ExibirSucesso(Result result)
        {
            var success = result.Successes.First();
            switch(success)
            {
                case SuccessImport<Pet> i:
                    ExibirImportacao(i.Entities);
                    break;
                
                case SuccessImport<Cliente> i:
                    ExibirImportacao(i.Entities);
                    break;

                case SuccessList<Pet> l:
                    ExibirEntities(l.Entities);
                    break;
                
                case SuccessList<Cliente> l:
                    ExibirEntities(l.Entities);
                    break;

                case SuccessShow<Pet> ss:
                    ExibirListaAImportar(ss.Entities);
                    break;
                
                case SuccessShow<Cliente> ss:
                    ExibirListaAImportar(ss.Entities);
                    break;

                case SuccessHelp h:
                    if(h.Comando is null)
                    {
                        ExibirComandos();
                    }

                    ExibirComandoEspecifico(h.Comando!);
                    break;
            }
        }

        private static void ExibirFalha(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;

            var error = result.Errors.First();
            var reason = error.Reasons.FirstOrDefault();
            System.Console.WriteLine($"Aconteceu um exceção: {error.Message}\nCausada por: {reason?.Message}");
            
        }

        private static void ExibirImportacao(IEnumerable<Pet> entities)
        {
            ExibirEntities(entities);
            System.Console.WriteLine("\n\nImportacao realizada com sucesso !!!.");
        }

        private static void ExibirImportacao(IEnumerable<Cliente> entities)
        {
            ExibirEntities(entities);
            System.Console.WriteLine("\n\nImportacao realizada com sucesso !!!.");
        }

        private static void ExibirEntities(IEnumerable<Pet> entities)
        {
            foreach(var p in entities)
                System.Console.WriteLine(p);
        }
        
        private static void ExibirEntities(IEnumerable<Cliente> entities)
        {
            foreach(var p in entities)
                System.Console.WriteLine(p);
        }

        private static void ExibirListaAImportar(IEnumerable<Pet> entities)
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            ExibirEntities(entities);
        }
        
        private static void ExibirListaAImportar(IEnumerable<Cliente> entities)
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            ExibirEntities(entities);
        }

        private static void ExibirComandos()
        {
            System.Console.WriteLine
            (
                "Adopet (1.0) - Aplicativo de linha de comando (CLI).\n" +
                "Lista de comandos.\n" +
                "import-cliente ou import-pet\n" +
                "help\n" +
                "list-cliente ou list-pet\n" +
                "show-cliente ou show-pet\n" +
                "Execute 'adopet help [comando]' para obter mais informações sobre um comando."
            );
        }

        private static void ExibirComandoEspecifico(string comando)
        {
            System.Console.WriteLine(comando);
        }

        internal static void ExibeException(Exception e)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(e.Message);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
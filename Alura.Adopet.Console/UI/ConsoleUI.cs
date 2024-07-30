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

                case SuccessList l:
                    ExibirPets(l.Pets);
                    break;

                case SuccessShow ss:
                    ExibirListaAImportar(ss.Pets);
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

        private static void ExibirImportacao(IEnumerable<Pet> pets)
        {
            ExibirPets(pets);
            System.Console.WriteLine("\n\nImportacao realizada com sucesso !!!.");
        }
        private static void ExibirPets(IEnumerable<Pet> pets)
        {
            foreach(var p in pets)
                System.Console.WriteLine(p);
        }

        private static void ExibirListaAImportar(IEnumerable<Pet> pets)
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            ExibirPets(pets);
        }

        private static void ExibirComandos()
        {
            System.Console.WriteLine
            (
                "Adopet (1.0) - Aplicativo de linha de comando (CLI).\n" +
                "Lista de comandos.\n" +
                "Import\n" +
                "Help\n" +
                "List\n" +
                "Show\n" +
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
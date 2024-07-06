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
                }
            }
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ExibirFalha(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;

            var error = result.Errors.First();
            System.Console.WriteLine($"Aconteceu um exceção: {error.Message}");
        }
    }
}
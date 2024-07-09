using FluentResults;

namespace Alura.Adopet.Console.SuccessResult
{
    public class SuccessHelp(string? comando = null) : Success
    {
        public string? Comando { get; set; } = comando;
    }
}
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Interfaces
{
    public interface IComando
    {
        public Task<Result> ExecutarComando();
    }
}
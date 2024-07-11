using FluentResults;

namespace Alura.Adopet.Console.Services.Interfaces
{
    public interface IComando
    {
        public Task<Result> ExecutarComando();
    }
}
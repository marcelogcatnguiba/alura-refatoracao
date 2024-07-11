using FluentResults;

namespace Alura.Adopet.Console.Services
{
    public interface IComando
    {
        public Task<Result> ExecutarComando();
    }
}
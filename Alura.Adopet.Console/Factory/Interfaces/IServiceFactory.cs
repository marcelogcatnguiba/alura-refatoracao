using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Factory.Interfaces
{
    public interface IServiceFactory<T>
    {
        IAPIService<T> CriarServico();
    }
}
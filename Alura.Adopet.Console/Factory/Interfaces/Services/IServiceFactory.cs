using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Factory.Interfaces.Services
{
    public interface IServiceFactory<T>
    {
        IApiService<T> CriarServico();
    }
}
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Factory.Services
{
    public class ClienteServiceFactory : IServiceFactory<Cliente>
    {
        public IAPIService<Cliente> CriarServico()
        {
            var cliente = new HttpClientFactory().CreateClient();
            return new ClienteService(cliente);
        }
    }
}
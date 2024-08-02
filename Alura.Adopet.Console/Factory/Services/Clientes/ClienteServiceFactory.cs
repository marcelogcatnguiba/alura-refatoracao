using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Factory.Services.Clientes
{
    public class ClienteServiceFactory : IServiceFactory<Cliente>
    {
        public IAPIService<Cliente> CriarServico()
        {
            var cliente = new HttpClientFactory(Configurations.ApiSettings.Uri).CreateClient();
            return new ClienteService(cliente);
        }
    }
}
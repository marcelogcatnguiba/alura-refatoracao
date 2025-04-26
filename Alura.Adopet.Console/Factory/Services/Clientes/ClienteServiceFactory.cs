using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces.Services;
using Alura.Adopet.Console.Services.Clientes;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Services.Shared;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Factory.Services.Clientes
{
    public class ClienteServiceFactory : IServiceFactory<Cliente>
    {
        public IApiService<Cliente> CriarServico()
        {
            var cliente = new HttpClientFactory(Configurations.ApiSettings.Uri).CreateClient();
            return new ClienteService(cliente);
        }
    }
}
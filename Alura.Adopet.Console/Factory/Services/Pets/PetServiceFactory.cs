using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces.Services;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Services.Pets;
using Alura.Adopet.Console.Services.Shared;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Factory.Services.Clientes
{
    public class PetServiceFactory : IServiceFactory<Pet>
    {
        public IApiService<Pet> CriarServico()
        {
            return new PetService(new HttpClientFactory(Configurations.ApiSettings.Uri).CreateClient());
        }
    }
}
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Factory.Services.Clientes
{
    public class PetServiceFactory : IServiceFactory<Pet>
    {
        public IAPIService<Pet> CriarServico()
        {
            return new PetService(new HttpClientFactory(Configurations.ApiSettings.Uri).CreateClient());
        }
    }
}
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.ConfigureHttp.Interfaces
{
    public interface IAPIService
    {
        Task<HttpResponseMessage> CreatePetAsync(Pet pet);
        Task<IEnumerable<Pet>?> ListPetsAsync();
    }
}
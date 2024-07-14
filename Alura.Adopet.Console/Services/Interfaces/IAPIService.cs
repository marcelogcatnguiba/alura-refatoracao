namespace Alura.Adopet.Console.Services.Interfaces
{
    public interface IAPIService<T>
    {
        Task CreatePetAsync(T obj);
        Task<IEnumerable<T>?> ListPetsAsync();
    }
}
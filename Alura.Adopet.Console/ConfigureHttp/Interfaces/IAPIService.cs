namespace Alura.Adopet.Console.ConfigureHttp.Interfaces
{
    public interface IAPIService<T>
    {
        Task CreatePetAsync(T pet);
        Task<IEnumerable<T>?> ListPetsAsync();
    }
}
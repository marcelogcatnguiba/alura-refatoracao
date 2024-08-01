namespace Alura.Adopet.Console.Services.Interfaces
{
    public interface IAPIService<T>
    {
        Task CreateAsync(T obj);
        Task<IEnumerable<T>?> ListAsync();
    }
}
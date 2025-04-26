namespace Alura.Adopet.Console.Services.Interfaces
{
    public interface IApiService<T>
    {
        Task CreateAsync(T obj);
        Task<IEnumerable<T>?> ListAsync();
    }
}
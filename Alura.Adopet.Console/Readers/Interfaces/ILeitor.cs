namespace Alura.Adopet.Console.Readers.Interfaces
{
    public interface ILeitor<T>
    {
        IEnumerable<T> RealizarLeitura();
    }
}
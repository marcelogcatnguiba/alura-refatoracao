namespace Alura.Adopet.Console.Leitores.Interfaces
{
    public interface ILeitor<T>
    {
        IEnumerable<T> RealizarLeitura();
    }
}
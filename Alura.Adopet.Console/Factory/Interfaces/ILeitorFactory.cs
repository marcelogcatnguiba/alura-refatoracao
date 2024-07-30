using Alura.Adopet.Console.Readers.Interfaces;

namespace Alura.Adopet.Console.Factory.Interfaces
{
    public interface ILeitorFactory<T>
    {
        bool ConsegueCriarLeitor(Type? type);
        ILeitor<T> CriarLeitor(string caminhoArquivo);
    }
}
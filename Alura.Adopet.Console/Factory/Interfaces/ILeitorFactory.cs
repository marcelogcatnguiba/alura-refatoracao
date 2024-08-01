using Alura.Adopet.Console.Leitores.Interfaces;

namespace Alura.Adopet.Console.Factory.Interfaces
{
    public interface ILeitorFactory<T>
    {
        bool ConsegueCriarLeitor(Type? type);
        ILeitor<T> CriarLeitor(string caminhoArquivo);
    }
}
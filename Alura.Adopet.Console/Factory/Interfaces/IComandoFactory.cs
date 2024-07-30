using Alura.Adopet.Console.Comandos.Interfaces;

namespace Alura.Adopet.Console.Factory.Interfaces
{
    public interface IComandoFactory
    {
        bool ConsegueCriarComando(Type? type);
        IComando CriarComando(string[] args);
    }
}
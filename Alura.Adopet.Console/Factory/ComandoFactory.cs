using Alura.Adopet.Console.Comandos.Interfaces;

namespace Alura.Adopet.Console.Factory
{
    public abstract class ComandoFactory
    {
        public abstract IComando CriarComando(string comando);
    }
}
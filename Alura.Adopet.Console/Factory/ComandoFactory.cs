
using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Factory
{
    public abstract class ComandoFactory
    {
        public abstract IComando CriarComando(TipoComando comando);
    }
}
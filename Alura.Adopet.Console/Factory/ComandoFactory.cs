using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Factory
{
    public abstract class ComandoFactory
    {
        public abstract IComando CriarComando(TipoComando comando);
    }
}
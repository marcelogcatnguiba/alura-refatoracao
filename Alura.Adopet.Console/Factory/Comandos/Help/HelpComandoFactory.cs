using Alura.Adopet.Console.Comandos.Help;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Factory.Interfaces;

namespace Alura.Adopet.Console.Factory.Comandos.Help
{
    public class HelpComandoFactory : IComandoFactory
    {
        public bool ConsegueCriarComando(Type? type)
        {
            return type?.IsAssignableTo(typeof(HelpComando)) ?? false;
        }

        public IComando CriarComando(string[] args)
        {
            return new HelpComando(args);
        }
    }
}
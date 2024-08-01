using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Comandos.Show;
using Alura.Adopet.Console.Factory.Interfaces;
using Alura.Adopet.Console.Factory.Leitores;

namespace Alura.Adopet.Console.Factory.Comandos.Show
{
    public class ShowComandoFactory : IComandoFactory
    {
        public bool ConsegueCriarComando(Type? type)
        {
            return type?.IsAssignableTo(typeof(ShowComando)) ?? false;
        }

        public IComando? CriarComando(string[] args)
        {
            var leitor = SelecionaLeitorPet.CriarLeitor(args[1]);

            if(leitor is not null)
            {
                return new ShowComando(leitor);
            }

            return null;
        }
    }
}
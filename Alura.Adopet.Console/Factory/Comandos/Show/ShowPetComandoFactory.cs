using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Comandos.Show;
using Alura.Adopet.Console.Factory.Interfaces.Commands;
using Alura.Adopet.Console.Factory.Leitores;

namespace Alura.Adopet.Console.Factory.Comandos.Show
{
    public class ShowPetComandoFactory : IComandoFactory
    {
        public bool ConsegueCriarComando(Type? type)
        {
            return type?.IsAssignableTo(typeof(ShowPetComando)) ?? false;
        }

        public IComando? CriarComando(string[] args)
        {
            var leitor = SelecionaLeitorPet.CriarLeitor(args[1]);

            if(leitor is not null)
            {
                return new ShowPetComando(leitor);
            }

            return null;
        }
    }
}
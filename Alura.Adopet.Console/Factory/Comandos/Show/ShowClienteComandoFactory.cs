using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Comandos.Show;
using Alura.Adopet.Console.Factory.Interfaces.Commands;
using Alura.Adopet.Console.Factory.Leitores;

namespace Alura.Adopet.Console.Factory.Comandos.Show
{
    public class ShowClienteComandoFactory : IComandoFactory
    {
        public bool ConsegueCriarComando(Type? type)
        {
            return type?.IsAssignableTo(typeof(ShowClienteComando)) ?? false;
        }

        public IComando? CriarComando(string[] args)
        {
            var leitor = SelecionaLeitorCliente.CriarLeitor(args[1]);

            return leitor is not null ? new ShowClienteComando(leitor) : null;
        }
    }
}
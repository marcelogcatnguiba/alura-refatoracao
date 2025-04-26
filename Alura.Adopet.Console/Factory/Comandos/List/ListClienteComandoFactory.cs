using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Comandos.List;
using Alura.Adopet.Console.Factory.Interfaces.Commands;
using Alura.Adopet.Console.Factory.Services.Main;

namespace Alura.Adopet.Console.Factory.Comandos.List
{
    public class ListClienteComandoFactory : IComandoFactory
    {
        public bool ConsegueCriarComando(Type? type)
        {
            return type?.IsAssignableTo(typeof(ListClienteComando)) ?? false;
        }

        public IComando? CriarComando(string[] args)
        {
            var service = SelecionaServicoCliente.CriarServico();
            return service is not null ? new ListClienteComando(service) : null;
        }
    }
}
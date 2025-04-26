using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Comandos.List;
using Alura.Adopet.Console.Factory.Interfaces.Commands;
using Alura.Adopet.Console.Factory.Services.Main;

namespace Alura.Adopet.Console.Factory.Comandos.List
{
    public class ListPetComandoFactory : IComandoFactory
    {
        public bool ConsegueCriarComando(Type? type)
        {
            return type?.IsAssignableTo(typeof(ListPetComando)) ?? false;
        }

        public IComando? CriarComando(string[] args)
        {
            var service = SelecionaServicoPet.CriarServico();
            return service is not null ? new ListPetComando(service) : null;
        }
    }
}
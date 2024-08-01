using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Leitores.LeitoresClientes;

namespace Alura.Adopet.Console.Factory.Leitores.Clientes
{
    public class LeitorCSVClienteFactory : ILeitorFactory<Cliente>
    {
        public bool ConsegueCriarLeitor(Type? type)
        {
            return type?.IsAssignableTo(typeof(LeitorCSVCliente)) ?? false;
        }

        public ILeitor<Cliente> CriarLeitor(string caminhoArquivo)
        {
            return new LeitorCSVCliente(caminhoArquivo);
        }
    }
}
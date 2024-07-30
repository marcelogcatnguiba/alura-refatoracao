using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces;
using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.Readers.Interfaces;

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
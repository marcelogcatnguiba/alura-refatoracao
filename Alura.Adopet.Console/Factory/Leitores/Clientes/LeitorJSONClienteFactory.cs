using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Leitores.LeitoresClientes;

namespace Alura.Adopet.Console.Factory.Leitores.Clientes
{
    public class LeitorJSONClienteFactory : ILeitorFactory<Cliente>
    {
        public bool ConsegueCriarLeitor(Type? type)
        {
            return type?.IsAssignableTo(typeof(LeitorJSONCliente)) ?? false;
        }

        public ILeitor<Cliente> CriarLeitor(string caminhoArquivo)
        {
            return new LeitorJSONCliente(caminhoArquivo);
        }
    }
}
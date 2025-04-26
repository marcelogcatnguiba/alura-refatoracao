using Alura.Adopet.Console.Comandos.Import;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Factory.Interfaces.Commands;
using Alura.Adopet.Console.Factory.Leitores;
using Alura.Adopet.Console.Factory.Services.Main;

namespace Alura.Adopet.Console.Factory.Comandos.Import
{
    public class ImportClienteComandoFactory : IComandoFactory
    {
        public bool ConsegueCriarComando(Type? type)
        {
            return type?.IsAssignableTo(typeof(ImportClienteComando)) ?? false;
        }

        public IComando? CriarComando(string[] args)
        {
            var leitor = SelecionaLeitorCliente.CriarLeitor(caminhoArquivo: args[1]);
            var service = SelecionaServicoCliente.CriarServico();

            return new ImportClienteComando(leitor!, service!);
        }
    }
}
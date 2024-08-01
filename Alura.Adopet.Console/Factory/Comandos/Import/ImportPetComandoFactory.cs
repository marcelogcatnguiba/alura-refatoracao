using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Factory.Interfaces;
using Alura.Adopet.Console.Factory.Leitores;
using Alura.Adopet.Console.Factory.Services;

namespace Alura.Adopet.Console.Factory.Comandos.Import
{
    public class ImportPetComandoFactory : IComandoFactory
    {
        public bool ConsegueCriarComando(Type? type)
        {
            return type?.IsAssignableTo(typeof(ImportPetComando)) ?? false;
        }

        public IComando CriarComando(string[] args)
        {
            var leitor = SelecionaLeitorPet.CriarLeitor(args[1]);
            var service = SelecionaServicoPet.CriarServico();

            return new ImportPetComando(leitor!, service!);
        }
    }
}
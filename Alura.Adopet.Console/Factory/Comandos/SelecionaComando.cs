using System.Reflection;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Factory.Interfaces;

namespace Alura.Adopet.Console.Factory.Comandos
{
    public static class SelecionaComando
    {
        public static IComando? CriarComando(string[] args)
        {
            if(args is null || args.Length.Equals(0))
            {
                return null;
            }

            var comando = args[0];

            var listaFabricas = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => !x.IsInterface && x.IsAssignableTo(typeof(IComandoFactory)))
                .Select(x => Activator.CreateInstance(x) as IComandoFactory);
            
            var tipo = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => !x.IsInterface && x.IsAssignableTo(typeof(IComando)))
                .FirstOrDefault(x => x.GetCustomAttributes<ClassDocuments>().Any(x => x.Comando.Equals(comando)));

            var fabrica = listaFabricas.FirstOrDefault(x => x!.ConsegueCriarComando(tipo));

            return fabrica?.CriarComando(args);
        }
    }
}
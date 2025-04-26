using System.Reflection;
using Alura.Adopet.Console.Factory.Interfaces.Leitores;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Leitores.Shared;

namespace Alura.Adopet.Console.Factory.Leitores.Main
{
    public abstract class SelecionaLeitor<T>
    {
        public static ILeitor<T>? CriarLeitor(string caminhoArquivo)
        {
            var extensao = Path.GetExtension(caminhoArquivo);

            var fabricas = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract && x.IsAssignableTo(typeof(ILeitorFactory<T>)))
                .Select(x => Activator.CreateInstance(x) as ILeitorFactory<T>);

            var tipoArquivo =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => !x.IsInterface && x.IsAssignableTo(typeof(ILeitor<T>)))
                .FirstOrDefault(x => x.GetCustomAttributes<LeitorAtribute>().Any(x => x.ExtensaoArquivo.Equals(extensao)));
            
            var leitor = fabricas.FirstOrDefault(x => x!.ConsegueCriarLeitor(tipoArquivo));

            return leitor?.CriarLeitor(caminhoArquivo);
        }
    }
}
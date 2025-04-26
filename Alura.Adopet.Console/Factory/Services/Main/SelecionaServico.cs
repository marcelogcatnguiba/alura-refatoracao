using System.Reflection;
using Alura.Adopet.Console.Factory.Interfaces.Services;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Factory.Services.Main
{
    public abstract class SelecionaServico<T>
    {
        public static IApiService<T>? CriarServico()
        {
            var fabricas = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract && x.IsAssignableTo(typeof(IServiceFactory<T>)))
                .Select(x => Activator.CreateInstance(x) as IServiceFactory<T>);
            
            var service = fabricas.FirstOrDefault();
            return service?.CriarServico();
        }
    }
}
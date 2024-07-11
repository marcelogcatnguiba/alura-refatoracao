using System.Reflection;
using Alura.Adopet.Console.Exeptions;

namespace Alura.Adopet.Console.Documentation
{
    public static class ListaDeDocumentacao
    {
        public static string GetDocumentacao(string comando)
        {
            Dictionary<string, ClassDocuments> _dic = [];

            _dic = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetCustomAttributes<ClassDocuments>().Any())
                .Select(x => x.GetCustomAttribute<ClassDocuments>()!)
                .ToDictionary(x => x.Comando);

            if (_dic.ContainsKey(comando.ToLower()))
            {
                return _dic[comando].Descricao;
            }
            
            throw new DocumentationException($"O comando {comando} não existe na lista de comandos");
        }
    }
}
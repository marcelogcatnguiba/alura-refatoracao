using System.Reflection;

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

            if (_dic.ContainsKey(comando.ToLower())) return _dic[comando].Descricao;

            throw new Exception("Comando invalido");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils
{
    public static class ListaDeDocumentacao
    {
        public static string GetDocumentacao(string comando)
        {
            Dictionary<string, ClassDocuments> _dic = new Dictionary<string, ClassDocuments>();

            _dic = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetCustomAttributes<ClassDocuments>().Any())
                .Select(x => x.GetCustomAttribute<ClassDocuments>()!)
                .ToDictionary(x => x.Comando);

            if (_dic.ContainsKey(comando.ToLower()))
                return _dic[comando].Descricao;
            else
                throw new Exception("Comando invalido");
        }
    }
}
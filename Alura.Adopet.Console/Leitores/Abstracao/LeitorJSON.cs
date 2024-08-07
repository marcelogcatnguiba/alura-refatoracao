using Alura.Adopet.Console.Leitores.Interfaces;
using Newtonsoft.Json;

namespace Alura.Adopet.Console.Leitores.Abstracao
{
    public abstract class LeitorJSON<T>(string caminhoDoArquivo) : ILeitor<T>
    {
        private readonly string _caminho = caminhoDoArquivo;

        public IEnumerable<T> RealizarLeitura()
        {
            try
            {   
                using StreamReader streamReader = new(_caminho);
                var jsonString = streamReader.ReadToEnd();
                var objs = RetornaClassFromJSON(jsonString);

                return objs!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static List<T> RetornaClassFromJSON(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json)!;
        }
    }
}
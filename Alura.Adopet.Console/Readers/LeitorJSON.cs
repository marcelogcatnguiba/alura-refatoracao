using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Readers.Interfaces;
using Newtonsoft.Json;

namespace Alura.Adopet.Console.Readers
{
    public class LeitorJSON(string caminhoDoArquivo) : ILeitor<Pet>
    {
        private readonly string _caminho = caminhoDoArquivo;

        public IEnumerable<Pet> RealizarLeitura()
        {
            try
            {   
                using StreamReader streamReader = new(_caminho);
                var jsonString = streamReader.ReadToEnd();
                var pets = JsonConvert.DeserializeObject<List<Pet>>(jsonString);

                return pets!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
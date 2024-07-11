using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Utils.Extensions;

namespace Alura.Adopet.Console.Utils
{
    public class LeitorArquivo(string caminhoDoArquivo)
    {
        private readonly string _caminhoDoArquivo = caminhoDoArquivo;
        
        public virtual IEnumerable<Pet> RealizarLeitura()
        {
            List<Pet> listaDePet = [];
            using (StreamReader sr = new (_caminhoDoArquivo))
            {
                while (!sr.EndOfStream)
                {
                    string pet = sr.ReadLine()!;
                    listaDePet.Add(pet!.RetornaPetString());
                }
            }

            return listaDePet;
        }
    }
}
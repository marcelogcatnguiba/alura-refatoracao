using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Utils.Extensions;

namespace Alura.Adopet.Console.Utils
{
    public class LeitorArquivo
    {
        public virtual IEnumerable<Pet> LeitorArquivoDePets(string _caminhoArquivoImportacao)
        {
            List<Pet> listaDePet = new();
            using (StreamReader sr = new StreamReader(_caminhoArquivoImportacao))
            {
                bool naoFimArquivo = !sr.EndOfStream;
                while (naoFimArquivo)
                {
                    string pet = sr.ReadLine()!;
                    listaDePet.Add(pet!.RetornaPetString());
                }
            }

            return listaDePet;
        }
    }
}
using Alura.Adopet.Console.Utils.Extensions;

namespace Alura.Adopet.Console.Utils
{
    public static class LeitorArquivo
    {
        public static IEnumerable<Pet> LeitorArquivoDePets(string caminhoArquivoImportacao)
        {
            var listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(caminhoArquivoImportacao))
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
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
                bool fimDoArquivo = sr.EndOfStream;
                while (fimDoArquivo is false)
                {
                    // string[] propriedades = sr.ReadLine()!.Split(';');
                    // Pet pet = new Pet(Guid.Parse(propriedades[0]), propriedades[1], TipoPet.Cachorro);

                    string pet = sr.ReadLine()!;
                    listaDePet.Add(pet!.RetornaPetString());
                }
            }

            return listaDePet;
        }
    }
}
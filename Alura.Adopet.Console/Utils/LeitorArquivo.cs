namespace Alura.Adopet.Console.Utils
{
    public static class LeitorArquivo
    {
        public static IEnumerable<Pet> LeitorArquivoDePets(string caminhoArquivoImportacao)
        {
            var listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(caminhoArquivoImportacao))
            {
                while (!sr.EndOfStream)
                {
                    string[] propriedades = sr.ReadLine()!.Split(';');
                    Pet pet = new Pet(Guid.Parse(propriedades[0]), propriedades[1], TipoPet.Cachorro);

                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}
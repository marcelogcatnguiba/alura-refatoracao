using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Utils.Extensions;

namespace Alura.Adopet.Console.Utils
{
    public class LeitorArquivo
    {
        private readonly string _caminhoArquivoImportacao;

        public LeitorArquivo()
        {
            _caminhoArquivoImportacao = Configuration.CaminhoArquivoImportacao;
        }
        
        public virtual IEnumerable<Pet> LeitorArquivoDePets(string _caminhoArquivoImportacao)
        {
            var listaDePet = new List<Pet>();
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
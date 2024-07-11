using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Exeptions;
using Alura.Adopet.Console.Extensions;

namespace Alura.Adopet.Console.Readers
{
    public class LeitorCSV(string caminhoDoArquivo)
    {
        private readonly string _caminhoDoArquivo = caminhoDoArquivo;
        
        public virtual IEnumerable<Pet> RealizarLeitura()
        {
            LeitorArquivosException
                .Quando(ArquivoNaoCSV(), "Formato de arquivo invalido");

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

        private bool ArquivoNaoCSV()
        {
            return !Path.GetExtension(_caminhoDoArquivo).Equals("csv");
        }
    }
}
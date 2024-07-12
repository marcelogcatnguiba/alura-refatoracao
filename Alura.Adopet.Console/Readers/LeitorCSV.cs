using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Exeptions;
using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Readers.Result;

namespace Alura.Adopet.Console.Readers
{
    public class LeitorCSV(string caminhoDoArquivo) : ILeitor
    {
        private readonly string _caminhoDoArquivo = caminhoDoArquivo;
        
        public virtual ResultReader RealizarLeitura()
        {
            LeitorArquivosException
                .Quando(ArquivoNaoCSV(), "Formato de arquivo invalido");

            List<Pet> listaDePet = [];
            using (StreamReader sr = new (_caminhoDoArquivo))
            {
                while(!sr.EndOfStream)
                {
                    string pet = sr.ReadLine()!;
                    listaDePet.Add(pet!.RetornaPetString());
                }
            }

            var result = new ResultReader
            {
                Pets = listaDePet
            };

            return result;
        }

        private bool ArquivoNaoCSV()
        {
            return !Path.GetExtension(_caminhoDoArquivo).Equals("csv");
        }
    }
}
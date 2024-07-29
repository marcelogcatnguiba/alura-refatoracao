using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Exeptions;
using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Readers.LeitoresPet;

namespace Alura.Adopet.Console.Factory.Reader
{
    public class SelecionaReader(string caminhoDoArquivo) : ReaderFactory
    {
        private readonly string _caminhoDoArquivo = caminhoDoArquivo;
        private readonly string _extensao = Path.GetExtension(caminhoDoArquivo);

        public override ILeitor<Pet> CriarLeitor()
        {
            switch(_extensao)
            {
                case ".csv":
                    return new LeitorCSVPet(_caminhoDoArquivo);
                
                case ".json":
                    return new LeitorJSONPet(_caminhoDoArquivo);
                    
                default:
                    throw new LeitorArquivosException($"Formato do arquivo invalido: {_extensao}");
            }
        }
    }
}
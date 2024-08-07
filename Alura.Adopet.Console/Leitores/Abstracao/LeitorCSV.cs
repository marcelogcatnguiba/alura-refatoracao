using Alura.Adopet.Console.Leitores.Interfaces;

namespace Alura.Adopet.Console.Leitores.Abstracao
{
    public abstract class LeitorCSV<T>(string caminhoDoArquivo) : ILeitor<T>
    {
        private readonly string _caminhoDoArquivo = caminhoDoArquivo;
        
        public virtual IEnumerable<T> RealizarLeitura()
        {
            List<T> result = [];
            using (StreamReader sr = new (_caminhoDoArquivo))
            {
                while(!sr.EndOfStream)
                {
                    string linha = sr.ReadLine()!;
                    var obj = RetornaClassFromLine(linha);
                    result.Add(obj);
                }
            }

            return result;
        }

        public abstract T RetornaClassFromLine(string line);
    }
}
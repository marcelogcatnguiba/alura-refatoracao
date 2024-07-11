using Alura.Adopet.Console.Exeptions;
using Alura.Adopet.Console.Readers;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Readers
{
    public class LeitorCSVTest
    {
        [Fact]
        public void DeveRetornarException_QuandoArquivoNaoForCSV()
        {
            LeitorCSV leitor = new("texto.txt");
            
            Action act = () => leitor.RealizarLeitura();

            act.Should().Throw<LeitorArquivosException>().WithMessage("Formato de arquivo invalido");
        }
    }
}
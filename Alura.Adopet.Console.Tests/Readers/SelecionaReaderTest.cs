using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Exeptions;
using Alura.Adopet.Console.Leitores;
using Alura.Adopet.Console.Leitores.Abstracao;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Readers
{
    public class SelecionaReaderTest
    {
        // [Fact]
        // public void DeveRetornarLeitorCSV_QuandoExtensaoArquivoCSV()
        // {
        //     string arquivo = "pets.csv";
        //     var factory = new SelecionaReader(arquivo);

        //     var result = factory.CriarLeitor();

        //     result.Should().BeOfType<LeitorCSVPet>();
        // }
        
        // [Fact]
        // public void DeveRetornarLeitorJSON_QuandoExtensaoArquivoJSON()
        // {
        //     string arquivo = "pets.json";
        //     var factory = new SelecionaReader(arquivo);

        //     var result = factory.CriarLeitor();

        //     result.Should().BeOfType<LeitorJSONPet>();
        // }

        // [Fact]
        // public void DeveRetornarErro_QuandoExtensaoInvalida()
        // {
        //     string arquivo = "pets.text";
        //     Action action = () => new SelecionaReader(arquivo).CriarLeitor();

        //     action.Should().Throw<LeitorArquivosException>().WithMessage("Formato do arquivo invalido: .text");

        // }
    }
}
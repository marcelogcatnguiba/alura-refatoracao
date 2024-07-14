using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.Readers.Result;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.SuccessResult;
using FluentAssertions;
using Moq;

namespace Alura.Adopet.Console.Tests.Comandos.Show
{
    public class ShowComandoTest
    {
        [Fact]
        public async Task DeveConterPetsNaLista()
        {
            ResultReader resultReader = new()
            {
                Pets = 
                [
                    new(Guid.NewGuid(), "Luna", TipoPet.Gato),
                    new(Guid.NewGuid(), "Mira", TipoPet.Cachorro),
                    new(Guid.NewGuid(), "Kira", TipoPet.Gato)
                ]
            };
            
            Mock<LeitorCSV> leitor = new(Configuration.CaminhoArquivoImportacao);
            leitor.Setup(x => x.RealizarLeitura()).Returns(resultReader);

            ShowComando show = new(leitor.Object);
            var success = await show.ExecutarComando();
            var result = (SuccessShow)success.Successes.First();

            result.Pets.Should().HaveCount(3);
        }
    }
}
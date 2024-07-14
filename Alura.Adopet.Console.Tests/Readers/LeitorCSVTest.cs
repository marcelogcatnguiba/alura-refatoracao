using Alura.Adopet.Console.Exeptions;
using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.Readers.Interfaces;
using FluentAssertions;
using Moq;

namespace Alura.Adopet.Console.Tests.Readers
{
    public class LeitorCSVTest : IDisposable
    {
        private readonly string _caminhoArquivo;
        public LeitorCSVTest()
        {
            string pets = 
            """
                456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1
                3aeff89d-7da2-4603-852e-d232fbdc56bd;Caito;1
                bcdcb7a4-1279-4a6b-97e9-da6378ae6437;Jujuba;2
                609c9b0d-aa02-459f-a340-256513fc9bad;Nina;2
                01303089-833f-46ff-9f06-77f9d4f89f1d;Perdido;1
            """;

            File.WriteAllText("pets.csv", pets);
            _caminhoArquivo = Path.GetFullPath("pets.csv");
        }

        [Fact]
        public void DeveRetornarListaPets_QuandoRealizarLeitura()
        {
            LeitorCSV leitor = new(_caminhoArquivo);
            var result = leitor.RealizarLeitura();

            result.Pets.Should().HaveCount(5);
        }

        public void Dispose()
        {
            File.Delete(_caminhoArquivo);
        }
    }
}
using Alura.Adopet.Console.Leitores.LeitoresClientes;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Leitores.Clientes
{
    public class LeitorCSVClienteTest : IDisposable
    {
        private readonly string _caminhoArquivo;
        public LeitorCSVClienteTest()
        {
            string clientes = 
            """
                456b24f4-19e2-4423-845d-4a80e8854a41;Fulnao de Tal;fulano@example.org
                3aeff89d-7da2-4603-852e-d232fbdc56bd;Jose Silva;silva@example.org
                609c9b0d-aa02-459f-a340-256513fc9bad;Rogerio Milano;milano@example.org
            """;

            File.WriteAllText("clientes.csv", clientes);
            _caminhoArquivo = Path.GetFullPath("clientes.csv");
        }

        [Fact]
        public void DeveRetornarClientesDoCSV()
        {
            LeitorCSVCliente leitor = new(_caminhoArquivo);

            var result = leitor.RealizarLeitura();

            result.Should().HaveCount(3);
            Dispose();
        }

        public void Dispose()
        {
            File.Delete(_caminhoArquivo);
            GC.SuppressFinalize(this);
        }
    }
}
using Alura.Adopet.Console.Factory.Leitores;
using Alura.Adopet.Console.Leitores.LeitoresClientes;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Factory.Leitores
{
    public class SelecionaLeitorClienteTest
    {
        [Fact]
        public void DeveRetornarLeitor_ClienteCSV()
        {
            var result = SelecionaLeitorCliente.CriarLeitor("lista.csv");

            result.Should().BeOfType<LeitorCSVCliente>();
        }
        
        [Fact]
        public void DeveRetornarLeitor_ClienteJSON()
        {
            var result = SelecionaLeitorCliente.CriarLeitor("lista.json");

            result.Should().BeOfType<LeitorJSONCliente>();
        }
    }
}
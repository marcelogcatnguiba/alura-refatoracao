using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Exeptions;
using Alura.Adopet.Console.Factory.Leitores;
using Alura.Adopet.Console.Leitores;
using Alura.Adopet.Console.Leitores.Abstracao;
using Alura.Adopet.Console.Leitores.LeitoresClientes;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Leitores
{
    public class SelecionaLeitorClienteTest
    {
        [Fact]
        public void DeveRetornarLeitor_CSVCliente()
        {
            var result = SelecionaLeitorCliente.CriarLeitor("lista.csv");
            result.Should().BeOfType<LeitorCSVCliente>();
        }
        
        [Fact]
        public void DeveRetornarLeitor_JSONCliente()
        {
            var result = SelecionaLeitorCliente.CriarLeitor("lista.json");
            result.Should().BeOfType<LeitorJSONCliente>();
        }
    }
}
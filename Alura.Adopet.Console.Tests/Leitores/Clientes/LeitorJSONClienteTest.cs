using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.LeitoresClientes;
using FluentAssertions;
using Newtonsoft.Json;

namespace Alura.Adopet.Console.Tests.Leitores.Clientes
{
    public class LeitorJSONClienteTest : IDisposable
    {
        private readonly string _caminhoArquivo;
        public LeitorJSONClienteTest()
        {
            List<Cliente> lista = 
            [
                new(Guid.NewGuid(), "Carlos", "carlos@yahoo.com"),
                new(Guid.NewGuid(), "Julio", "julio@yahoo.com"),
                new(Guid.NewGuid(), "Maria", "maria@yahoo.com")
            ];

            var json = JsonConvert.SerializeObject(lista);

            File.WriteAllText("clientes.json", json);
            _caminhoArquivo = Path.GetFullPath("clientes.json");
        }

        [Fact]
        public void DeveRetornarUmaListaCliente()
        {
            var leitor = new LeitorJSONCliente(_caminhoArquivo);

            var result = leitor.RealizarLeitura();

            result.Should().BeOfType<List<Cliente>>();
        }
       
        [Fact]
        public void DeveConterClienteNaLista()
        {
            var leitor = new LeitorJSONCliente(_caminhoArquivo);

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
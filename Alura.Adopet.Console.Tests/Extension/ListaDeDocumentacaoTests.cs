using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Tests.Extension
{
    public class ListaDeDocumentacaoTests
    {
        [Fact]
        [Trait("Documentacao", "Help")]
        public void DeveRetornarDocumentacao_Help()
        {
            var comando = "help";
            var result = ListaDeDocumentacao.GetDocumentacao(comando);
            Assert.Contains(comando, result);
        }

        [Fact]
        [Trait("Documentacao", "Import")]
        public void DeveRetornarDocumentacao_Import()
        {
            var comando = "import";
            var result = ListaDeDocumentacao.GetDocumentacao(comando);
            Assert.Contains(comando, result);
        }

        [Fact]
        [Trait("Documentacao", "List")]
        public void DeveRetornarDocumentacao_List()
        {
            var comando = "list";
            var result = ListaDeDocumentacao.GetDocumentacao(comando);
            Assert.Contains(comando, result);
        }
        
        [Fact]
        [Trait("Documentacao", "Show")]
        public void DeveRetornarDocumentacao_Show()
        {
            var comando = "show";
            var result = ListaDeDocumentacao.GetDocumentacao(comando);
            Assert.Contains(comando, result);
        }
    }
}
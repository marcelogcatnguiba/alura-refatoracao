using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Exeptions;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Documentation
{
    public class ListaDeDocumentacaoTests
    {
        [Fact]
        [Trait("Documentacao", "Help")]
        public void DeveRetornarDocumentacao_Help()
        {
            var comando = "help";
            var result = ListaDeDocumentacao.GetDocumentacao(comando);

            result
                .Should()
                .Be("Exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help");
        }

        [Theory]
        [InlineData("import-cliente")]
        [InlineData("import-pet")]
        public void DeveRetornarDocumentacao_Import(string comando)
        {
            var result = ListaDeDocumentacao.GetDocumentacao(comando);
            
            result
                .Should()
                .Be("Realiza a importação em lote de um arquivos.\nDigite adopet import-cliente ou import-pet <arquivo>");
        }

        [Fact]
        [Trait("Documentacao", "List")]
        public void DeveRetornarDocumentacao_List()
        {
            var comando = "list";
            var result = ListaDeDocumentacao.GetDocumentacao(comando);
            
            result
                .Should()
                .Be("Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list");
        }
        
        [Fact]
        [Trait("Documentacao", "Show")]
        public void DeveRetornarDocumentacao_Show()
        {
            var comando = "show-pet";
            var result = ListaDeDocumentacao.GetDocumentacao(comando);
            
            result
                .Should()
                .Be("Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.");
        }

        [Fact]
        public void DeveRetornarErro_QuandoNaoExistirDocumentacao()
        {
            var comando = "qualquer";
            Action action = () => ListaDeDocumentacao.GetDocumentacao(comando);

            action
                .Should()
                .Throw<DocumentationException>()
                .WithMessage($"O comando {comando} não existe na lista de comandos");
        }
    }
}
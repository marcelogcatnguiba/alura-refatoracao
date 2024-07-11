using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.SuccessResult;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Comandos.Help
{
    public class HelpServiceTest
    {
        [Fact]
        public async Task DeveMostrarDocumentacaoTotal_QuandoComandoNull()
        {
            HelpService help = new();

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando.Should().BeNull();
        }

        [Fact]
        public async Task DeveMostrarDocumentacao_Help()
        {
            HelpService help = new("help");

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando
                .Should()
                .Be("Exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help");
        }

        [Fact]
        public async Task DeveMostrarDocumentacao_Import()
        {
            HelpService help = new("import");

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando
                .Should()
                .Be("Realiza a importação em lote de um arquivos de pets.\nDigite adopet import <arquivo>");
        }

        [Fact]
        public async Task DeveMostrarDocumentacao_List()
        {
            HelpService help = new("list");

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando
                .Should()
                .Be("Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list");
        }
        
        [Fact]
        public async Task DeveMostrarDocumentacao_Show()
        {
            HelpService help = new("show");

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando
                .Should()
                .Be("Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.");
        }
    }
}
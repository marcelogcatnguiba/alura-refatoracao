using Alura.Adopet.Console.Comandos.Help;
using Alura.Adopet.Console.SuccessResult;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Comandos.Help
{
    public class HelpComandoTest
    {
        [Fact]
        public async Task DeveMostrarDocumentacaoTotal_QuandoComandoNull()
        {
            HelpComando help = new([]);

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando.Should().BeNull();
        }

        [Fact]
        public async Task DeveMostrarDocumentacao_Help()
        {
            HelpComando help = new(["help", "help"]);

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando
                .Should()
                .Be("Exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help");
        }

        [Theory]
        [InlineData("import-cliente")]
        [InlineData("import-pet")]
        public async Task DeveMostrarDocumentacao_Import(string comando)
        {
            HelpComando help = new(["help", comando]);

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando
                .Should()
                .Be("Realiza a importação em lote de um arquivos.\nDigite adopet import-cliente ou import-pet <arquivo>");
        }

        [Theory]
        [InlineData("list-pet")]
        [InlineData("list-cliente")]
        public async Task DeveMostrarDocumentacao_List(string comando)
        {
            HelpComando help = new(["help", comando]);

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando
                .Should()
                .Be("Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list");
        }
        
        [Theory]
        [InlineData("show-pet")]
        [InlineData("show-cliente")]
        public async Task DeveMostrarDocumentacao_Show(string comando)
        {
            HelpComando help = new(["help", comando]);

            var success = await help.ExecutarComando();
            var result = (SuccessHelp)success.Successes.First();

            result.Comando
                .Should()
                .Be("Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.");
        }
    }
}
using Alura.Adopet.Console.Factory.Comandos.Main;
using Alura.Adopet.Console.UI;
using FluentResults;

var comando = SelecionaComando.CriarComando(args);

if(comando is not null)
{
    var result = await comando!.ExecutarComando();
    ConsoleUI.ExibeResultado(result);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando invalido"));
}
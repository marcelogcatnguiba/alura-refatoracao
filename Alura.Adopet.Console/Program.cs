using Alura.Adopet.Console.Factory;
using Alura.Adopet.Console.UI;
using FluentResults;


// var comando = args[0].Trim();
// var helpComando = args.Length > 1 ? args[1] : null;

// SelecionaReader selecionaReader = new(Configuration.CaminhoArquivoImportacao);
// ILeitor<Pet> leitorArquivo = selecionaReader.CriarLeitor();
// IAPIService<Pet> httpClientPet = new PetService(new HttpClientFactory().CreateClient("adopet"));

// SelecionaComando selecionaComando = new(leitorArquivo, httpClientPet, helpComando);

// var comandoSelect = selecionaComando.CriarComando(comando);
// var result = await comandoSelect.ExecutarComando();

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



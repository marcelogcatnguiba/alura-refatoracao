using Alura.Adopet.Console;
using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.ConfigureHttp.Interfaces;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory;
using Alura.Adopet.Console.Factory.Reader;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.UI;

var comando = args[0].Trim();
var helpComando = args.Length > 1 ? args[1] : null;

SelecionaReader selecionaReader = new(Configuration.CaminhoArquivoImportacao);
ILeitor leitorArquivo = selecionaReader.CriarLeitor();

IAPIService<Pet> httpClientPet = new PetService(new PetClientFactory().CreateClient("adopet"));

SelecionaComando selecionaComando = new(leitorArquivo, httpClientPet, helpComando);
var comandoSelect = selecionaComando.CriarComando(comando);

var result = await comandoSelect.ExecutarComando();

ConsoleUI.ExibeResultado(result);
using Alura.Adopet.Console;
using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Factory;
using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.UI;

var comando = args[0].Trim();
var helpComando = args.Length > 1 ? args[1] : null;

LeitorCSV leitorArquivo = new(Configuration.CaminhoArquivoImportacao);
HttpClientPet httpClientPet = new(new PetClientFactory().CreateClient("adopet"));

SelecionaComandoFactory selecionaComando = new(leitorArquivo, httpClientPet, helpComando);
var comandoEnum = (TipoComando)Enum.Parse(typeof(TipoComando), comando.PrimeiraLetraMaiuscula());
var comandoSelect = selecionaComando.CriarComando(comandoEnum);

var result = await comandoSelect.ExecutarComando();

ConsoleUI.ExibeResultado(result);
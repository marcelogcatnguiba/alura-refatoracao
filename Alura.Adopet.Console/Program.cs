using Alura.Adopet.Console;
using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Factory;
using Alura.Adopet.Console.UI;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Console.Utils.Extensions;

var comando = args[0].Trim();

LeitorArquivo leitorArquivo = new(Configuration.CaminhoArquivoImportacao);
HttpClientPet httpClientPet = new(new PetClientFactory().CreateClient("adopet"));

SelecionaComandoFactory selecionaComando = new(leitorArquivo, httpClientPet);
var comandoEnum = (TipoComando)Enum.Parse(typeof(TipoComando), comando.PrimeiraLetraMaiuscula());
var comandoSelect = selecionaComando.CriarComando(comandoEnum);

var result = await comandoSelect.ExecutarComando(args);

ConsoleUI.ExibeResultado(result);
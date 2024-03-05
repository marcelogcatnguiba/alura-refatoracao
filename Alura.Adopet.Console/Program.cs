using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Repository;
using Alura.Adopet.Console.Services;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    var comando = args[0].Trim();
    HttpClientPet client;
    PetRepository repository;

    switch (comando)
    {
        case "import":
            client = new HttpClientPet();
            repository = new PetRepository(client.GetClient);
            var import = new ImportService(repository);
            await import.ImportarArquivoPets(caminhoArquivoImportacao: args[1]);
            break;

        case "help":
            var help = new HelpService();

            if (args.Length == 1) help.AjudaComandos();
            else help.AjudaComandoEspecifico(comando: args[1]);
            break;

        case "show":
            var show = new ShowService();
            show.ListarPetsDeArquivo(caminhoDoArquivo: args[1]);
            break;

        case "list":
            client = new HttpClientPet();
            repository = new PetRepository(client.GetClient);
            var list = new ListService(repository);
            await list.ListarPetsCadastrados();
            break;

        default:
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
using Alura.Adopet.Console.Services;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    var comando = args[0].Trim();
    switch (comando)
    {
        case "import":
            var import = new ImportService();
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
            var list = new ListService();
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
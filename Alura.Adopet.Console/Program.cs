﻿using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Factory;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Console.Utils.Extensions;

Console.ForegroundColor = ConsoleColor.Green;

try
{
    var comando = args[0].Trim();
    LeitorArquivo leitorArquivo = new();
    HttpClientPet httpClientPet = new(new PetClientFactory().CreateClient("adopet"));

    SelecionaComandoFactory selecionaComando = new(leitorArquivo, httpClientPet);
    var comandoEnum = (TipoComando)Enum.Parse(typeof(TipoComando), comando.PrimeiraLetraMaiuscula());
    var comandoSelect = selecionaComando.CriarComando(comandoEnum);

    await comandoSelect.ExecutarComando(args);
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
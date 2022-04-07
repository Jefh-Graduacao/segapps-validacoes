using System.Text.RegularExpressions;
using static System.Console;

const string caminhoArquivoWhitelist = "./whitelist.txt";
var regexCpf = new Regex(@"^((\d{3}\.){2}\d{3}\-\d{2}|\d{11})$");

if (args is not { Length: 2 })
{
    Console.ForegroundColor = ConsoleColor.Red;
    WriteLine("Este programa precisa de 2 entradas para ser executado.");
    WriteLine("\t1. Tipo de validação ('regex' ou 'whitelist')");
    WriteLine("\t2. Dado para ser validado");
    return;
}

var entrada = args[1];
var entradaVálida = args[0] switch
{
    "regex" => regexCpf.IsMatch(entrada),
    "whitelist" => File.ReadAllLines(caminhoArquivoWhitelist).Contains(entrada),
    _ => throw new Exception($"Tipo de validação deve ser 'regex' ou 'whitelist'")
};

WriteLine($"'{entrada}' é um CPF {(entradaVálida ? "válido" : "inválido")}");
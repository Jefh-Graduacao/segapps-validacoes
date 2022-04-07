using System.Text.RegularExpressions;

const string whiteListFilePath = "./whitelist.txt";
var regexCpf = new Regex(@"^((\d{3}\.){2}\d{3}\-\d{2}|\d{11})$");

var entrada = args?[1] ?? throw new Exception("Entrada deve ser informada");

var entradaVálida = args?[0] switch
{
    "regex" => ValidarComRegex(entrada),
    "whitelist" => ValidarComWhitelist(entrada),
    _ => throw new Exception($"Tipo de validação deve ser 'regex' ou 'whitelist'")
};

Console.WriteLine($"{entrada} é um CPF {(entradaVálida ? "válido" : "inválido")}");

bool ValidarComRegex(string entrada)
    => regexCpf.IsMatch(entrada);

bool ValidarComWhitelist(string entrada)
    => File.ReadAllLines(whiteListFilePath).Contains(entrada);

enum TipoValidacao { Regex, Whitelist }
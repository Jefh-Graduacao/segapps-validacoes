## Atividade 1

Crie uma expressão regular para validar cada um dos seguintes tipos de entrada:  
* Data (no formato dd/mm/aaaa)  
    ```regexp
    ^(0?[1-9]|[12][0-9]|3[01])\/(0?[1-9]|1[12])\/(\d{4})$
    ```
* Número inteiro (pode ser positivo ou negativo)  
    ```regexp
    ^(\-?)\d+$
    ```
* CPF  
    ```regexp
    ^(\d{3}\.\d{3}\.\d{3}\-\d{2}|\d{11})$
    ```
* Endereço IPv4  
    ```regexp
    ^((25[0-5]|2[0-4][0-9]|[01]?[0-9]?[0-9])(\.|$)){4}$
    ```

## Atividade 2

> Escolha um tipo de dado de entrada do exercício anterior (por exemplo, endereço IP):
> * Implemente um programa que receba o dado como entrada e o valide. O programa deve possuir 2 versões: uma que valida a entrada com expressões regulares e outra que valide com outro método (por exemplo, whitelist/blacklist ou filtragem). A implementação pode ser feita em qualquer linguagem de programação.
> * Após implementar os programas, responda: qual tipo de validação de entrada é mais robusto? Justifique sua resposta.

Decidi implementar uma validação de CPF. A implementação foi feita no mesmo programa, o tipo de validação e os dados devem ser fornecidos via argumentos de linha de comando.

### Execução do programa

Argumentos esperados: 
1. Tipo de validação: `regex` ou `whitelist`
2. Dado para ser validado

Por exemplo, para fazer uma validação do CPF **011.291.234-23** usando **regex**:

```bash
$> dotnet run regex 011.291.234-23
011.291.234-23 é um CPF válido
```

Como já informado, a segunda validação foi feita usando _whitelist_. E a validação usando regex é mais robusta em termos de desenvolvimento/manutenção e de tempo de execução. 

Para conseguir fazer uma implementação realmente funcional de _whitelist_ seria necessário listar **todas as entradas  válidas** para o programa. Isso consumiria Gigabytes de dados, mesmo para uma informação simples como um CPF.

* 9 caracteres por linha (1 caracter = 1 byte)
* 199.999.999.998 linhas
* 1.800.000.000.000 bytes
* ~1.800 Gigabyte

Além de ser um enorme trabalho para desenvolvimento e aumentar a dificuldade de manutenção, a leitura deste arquivo gigante é um processo lento e prejudica muito a experiência de uso do programa.

> 💡 O arquivo de whitelist usado neste exemplo apenas contém 2048 entradas. Então, o mesmo deve ser editado para validar uma entrada específica.
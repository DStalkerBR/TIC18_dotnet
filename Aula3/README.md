# Exercícios da Aula 3 do Módulo Avançado de C#

Exercícios realizados na Aula 3 compreendendo os seguintes tópicos:

## [Exercício 1 - Delegates](DelegatesEx/)

Neste exercício, utilizamos delegates e expressões lambda para processar uma lista de números.

1. Crie uma lista de números do tipo double e divida cada elemento por 2 usando o método `ConvertAll()` com um delegate `Converter`.
2. Imprima os elementos resultantes usando o método `ForEach()` com um delegate `Action`.

## [Exercício 2 - LINQ](MercadoLinq/)

Este exercício envolve o uso de LINQ para manipulação de dados de uma lista de compras de supermercado.

1. Ordene e retorne uma lista de itens de higiene por ordem decrescente de preço.
2. Retorne uma lista de itens com preço maior ou igual a R$ 5,00, ordenados por preço crescente.
3. Retorne uma lista de itens do tipo Comida ou Bebida, ordenados por nome em ordem alfabética.
4. Retorne a contagem de itens por tipo.
5. Retorne o preço máximo, mínimo e médio de cada tipo de item.

## [Exercício 3 – Threads](ThreadEx/)

Neste exercício, exploramos o uso de threads em C# para execução simultânea de tarefas.

1. Crie uma classe `Worker` com o método `Work()` que simule um trabalho.
2. Execute duas instâncias dessa classe em threads separadas, imprimindo mensagens de progresso.
3. Aguarde a conclusão de ambas as threads antes de encerrar o programa principal.

## [Exercício 4 – Async/Await](AsyncEx/)

Este exercício demonstra o uso de métodos assíncronos em C# com as palavras-chave async e await.

1. Crie um método assíncrono `DoWorkAsync` que simule um trabalho com Task.Delay.
2. Inicie duas tarefas assíncronas representando "Tarefa 1" e "Tarefa 2" no método Main.
3. Aguarde a conclusão de ambas as tarefas usando Task.WhenAll e imprima uma mensagem de conclusão.



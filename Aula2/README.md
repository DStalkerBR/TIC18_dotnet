# Exercícios da Aula 2

Exercícios realizados na Aula 2 compreendendo os seguintes tópicos:

## [Exercício 1: Conta Bancária com Exceções](Banco/)
- Implementação de uma classe `ContaBancaria` com métodos `Sacar`, `Depositar` e `Transferir`.
- Criação de exceções `ValorInvalidoException` e `SaldoInsuficienteException`.
- Demonstração de transações corretas e que geram exceções.


## [Exercício 2: Tratamento de Exceções](Excecoes/)
- Identificação e tratamento de exceção ao tentar chamar `ToString()` em um objeto nulo.
- Transformação da exceção em mensagem amigável.

## [Exercício 3: Enum Selector](EnumSelector/)
- Criação de um enum `Exercicio` para representar opções de exercícios.
- Exibição das opções de exercícios no console e solicitação de entrada do usuário.
- Conversão da entrada em um valor numérico e associação com o nome do exercício correspondente.

## [Exercício 4: Serviço com Generics](ServicoFabrica/)
- Implementação de uma classe `ServicoFabrica<T>` para criar instâncias de objetos do tipo `T`.
- Restrição para aceitar apenas tipos que implementam a interface `IServico` com o método `Executar()`.

## [Exercício 5: Triângulo com Structs e Generics](TrianguloGeometrico/)
- Criação das estruturas `Triangulo` e `Ponto` para representar triângulos e pontos geométricos.
- Uso de generics para parametrizar o tipo de dado das coordenadas dos pontos.

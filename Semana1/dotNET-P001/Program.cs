//Problema: Quais são os tipos de dados numéricos inteiros disponíveis no .NET? 
//Dê exemplos de uso para cada um deles através de exemplos.

 #region Tipo de dados
    // Representa números inteiros de 8 bits com sinal. Intervalo: -128 a 127.
    sbyte amplitudeAudio, amplitudeNormalizada;

    // Representa números inteiros de 8 bits sem sinal. Intervalo: 0 a 255.
    byte red, blue, green;

    // Representa números inteiros de 16 bits com sinal. Intervalo: -32,768 a 32,767.
    short leituraSensor, resultadoCorrecao;

    // Representa números inteiros de 16 bits sem sinal. Intervalo: 0 a 65,535.
    ushort referenciaCalibracao;

    // Representa números inteiros de 32 bits com sinal (tipo de dado inteiro padrão).
    // Intervalo: -2,147,483,648 a 2,147,483,647.
    int tempoUnix;

    // Representa números inteiros de 32 bits sem sinal. Intervalo: 0 a 4,294,967,295.
    uint populacaoPais;

    // Representa números inteiros de 64 bits com sinal. Intervalo: -9,223,372,036,854,775,808 a 9,223,372,036,854,775,807.
    long saldoBancario;

    // Representa números inteiros de 64 bits sem sinal. Intervalo: 0 a 18,446,744,073,709,551,615.
    ulong tamanhoArquivoEmBytes;

    // Um número inteiro de 32 ou 64 bits com sinal.
    nint tamanhoBuffer;

    // Um número inteiro de 32 ou 64 bits sem sinal.
    nuint dadoRecebido;

    // EXEMPLOS:
    Console.WriteLine("================================");
    Console.WriteLine("          Tipo de Dados          ");
    Console.WriteLine("================================");

    // sbyte:
    // Representando a intensidade de sinal de áudio normalizada 
    // para o intervalo de -1 a 1 antes de ser alimentada 
    // numa rede neural para treinamento
    amplitudeAudio  = -67;
    amplitudeNormalizada = (sbyte)(amplitudeAudio > 0 ? 1 : -1);
    Console.WriteLine("sbyte: Amplitude de Audio: " + amplitudeNormalizada);

    // byte:
    // Representando a cor roxa no formato RGB
    red = 153;
    green = 51;
    blue = 153;
    Console.WriteLine($"byte: Valor RGB: ({red}, {green}, {blue})");

    //short e ushort:
    // Representando o inteiro num sistema de 16 bits (como o Arduino Uno R3)
    leituraSensor = -2400;
    referenciaCalibracao = 8232;
    resultadoCorrecao = (short)(leituraSensor + referenciaCalibracao);
    Console.WriteLine($"short/ushort: Leitura do Sensor: {leituraSensor}, Referência de Calibração: {referenciaCalibracao}, Resultado da Correção: {resultadoCorrecao}");

    // int:
    // Representando o tempo unix em segundos (segundos desde 1º de janeiro de 1970) 
    tempoUnix = 1700098436;
    Console.WriteLine($"int: Tempo Unix: {tempoUnix} segundos desde 1º de janeiro de 1970");

    // uint:
    // Representa a população de um país que pode atingir 4 bilhões.
    populacaoPais = 600000000;
    Console.WriteLine($"uint: População do país: {populacaoPais}");

    // long:
    // Representa o saldo em uma conta bancária que pode exceder 2 trilhões.
    saldoBancario = -2750000000000;
    Console.WriteLine($"long: Saldo bancário após comprar a Microsoft: {saldoBancario}");

    // ulong:
    // Representando o número de bytes em um arquivo que pode ultrapassar 4 GB.
    tamanhoArquivoEmBytes = 5000000000UL;
    Console.WriteLine($"ulong: Tamanho do arquivo em bytes: {tamanhoArquivoEmBytes}");

    // nint e uint:
    // Os tipos nint e nuint foram introduzidos para promover portabilidade em ambientes de 32 e 64 bits,
    // sendo úteis em cenários de baixo nível, como interoperabilidade com APIs não gerenciadas ou com bibliotecas C 
    // que podem ter versões diferentes de 32 e 64 bits, manipulação de índices de coleções e alocação dinâmica de memória. 
    // Adaptam-se automaticamente ao tamanho do ponteiro, proporcionando uma abstração eficaz para escrever código que 
    // funciona independentemente da arquitetura do sistema.
    tamanhoBuffer = 1024;
    dadoRecebido = 42;
    Console.WriteLine($"nint: Tamanho do buffer: {tamanhoBuffer}");
    Console.WriteLine($"nuint: Dado Recebido de uma API: {dadoRecebido}");
#endregion


/* Problema: Suponha que você tenha uma variável do tipo double e deseja convertê-la 
em um tipo int. Como você faria essa conversão e o que aconteceria se a parte 
fracionária da variável double não pudesse ser convertida em um int? Resolva o 
problema através de um exemplo em C#. */
#region Conversão de Tipos de Dados
    double tipoDouble = 3.14;
    int tipoInt;
    tipoInt = (int) tipoDouble;
    Console.WriteLine("\n===============================");
    Console.WriteLine("  Conversão de Tipos de Dados   ");
    Console.WriteLine("===============================");
    Console.WriteLine("Valor do Double: " + tipoDouble);
    Console.WriteLine("Valor do Int: " + tipoInt); // A parte fracionaria de tipoDouble é truncada
#endregion 

/* 
Problema: Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular 
e exibir o resultado da adição, subtração, multiplicação e divisão de x por y. 
*/
#region Operadores Aritméticos
    int x = 10;
    int y = 3;
    int soma = x + y;
    int sub = x - y;
    int mult = x * y;
    int divisao = x / y;
    Console.WriteLine("\n===========================");
    Console.WriteLine("  Operadores Aritméticos   ");
    Console.WriteLine("===========================");
    Console.WriteLine($"Adição:        {x} + {y} = {soma}");
    Console.WriteLine($"Subtração:     {x} - {y} = {sub}");
    Console.WriteLine($"Multiplicação: {x} * {y} = {mult}");
    Console.WriteLine($"Divisão:       {x} / {y} = {divisao}");
#endregion

/* Problema: Considere as variáveis int a = 5 e int b = 8. Escreva código para determinar 
se a é maior que b e exiba o resultado. */
#region Operadores de Comparação:
    int a = 5;
    int b = 8;
    Console.WriteLine("\n==============================");
    Console.WriteLine("  Operadores de Comparação    ");
    Console.WriteLine("==============================");
    if (a > b){
        Console.WriteLine($"{a} > {b}? -> Verdadeiro");
    } else {
        Console.WriteLine($"{a} > {b}? -> Falso");
    }
#endregion

/* Problema: Você tem duas strings, string str1 = "Hello" e string str2 = "World". Escreva 
código para verificar se as duas strings são iguais e exibir o resultado. */
#region Operadores de Igualdade:
    string str1 = "Hello";
    string str2 = "World";
    Console.WriteLine("\n==============================");
    Console.WriteLine("   Operadores de Igualdade    ");
    Console.WriteLine("==============================");
    if (str1 == str2){
        Console.WriteLine($"As strings \"{str1}\" e \"{str2}\" são iguais");
    } {
        Console.WriteLine($"As strings \"{str1}\" e \"{str2}\" são diferentes");
    }
#endregion

/* Problema: Suponha que você tenha duas variáveis booleanas, bool condicao1 = true 
e bool condicao2 = false. Escreva código para verificar se ambas as condições são 
verdadeiras e exiba o resultado. */
#region Operadores Lógicos
    bool condicao1 = true;
    bool condicao2 = false;
    Console.WriteLine("\n==============================");
    Console.WriteLine("     Operadores Lógicos       ");
    Console.WriteLine("==============================");
    if (condicao1 && condicao2){
        Console.WriteLine($"{condicao1} && {condicao2}? Ambas as condições são verdadeiras");
    } else if(condicao1) {
        Console.WriteLine($"{condicao1} && {condicao2}? Somente a condição 1 é verdadeira");
    } else if (condicao2) {
        Console.WriteLine($"{condicao1} && {condicao2}? Somente a condição 2 é verdadeira");
    } else {
        Console.WriteLine($"{condicao1} && {condicao2}? Ambas as condições são falsas");
    }
#endregion

/* Problema: Dadas as variáveis int num1 = 7, int num2 = 3, e int num3 = 10, escreva 
código para verificar se num1 é maior do que num2 e se num3 é igual a num1 + num2. */
#region Desafio de Mistura de Operadores:
int num1 = 7; 
int num2 = 3;
int num3 = 10;
Console.WriteLine("\n==============================");
Console.WriteLine("   Mistura de Operadores      ");
Console.WriteLine("==============================");
if (num1 > num2 && num3 == (num1 + num2)){
    Console.WriteLine($"{num1} é maior que {num2} e {num3} é igual a soma de {num1} e {num2}");
}

#endregion
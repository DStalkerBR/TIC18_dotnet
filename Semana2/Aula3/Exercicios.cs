// See https://aka.ms/new-console-template for more information

#region Exemplo de Laço de Repetição: Foreach
string [] colecao = {"Item1", "Item2", "Item3", "Item4"};

foreach (var item in colecao)
{
    Console.WriteLine(item);
}

#endregion

// Escreva um programa em C# que imprime todos os números que são
// divisíveis por 3 ou por 4 entre 0 e 30;
#region  Números divisíveis
Console.WriteLine("Números divisíveis por 3 ou por 4: ");
    for (int num = 0; num <= 30; num++){
        if (num % 3 == 0 || num % 4 == 0){            
            Console.WriteLine(num);
        }
    }
#endregion

// Faça um programa em C# que imprima os primeiros números da série de
// Fibonacci até passar de 100. A série de Fibonacci é a seguinte: 0, 1, 1, 2, 3,
// 5, 8, 13, 21 etc... Para calculá-la, o primeiro elemento vale 0, o segundo vale
// 1, daí por diante, o n-ésimo elemento vale o (n-1)-ésimo elemento somado
// ao (n-2)-ésimo elemento (ex: 8 = 5 + 3)
#region Sequência Fibonacci
    int fib1 = 0;
    int fib2 = 1;
    int fib3 = 0;
    Console.WriteLine("================================");
    Console.WriteLine("       Sequência Fibonacci      ");
    Console.WriteLine("================================");
    Console.WriteLine(fib1);
    Console.WriteLine(fib2);
    while (fib3 <= 100){
        fib3 = fib1 + fib2;
        fib1 = fib2;
        fib2 = fib3;
        Console.WriteLine(fib3);
    }
#endregion

// Faça um programa que
// imprima a seguinte tabela
// até o nível 8:
#region Tabela de multiplicação
int n = 8;
Console.WriteLine("================================");
Console.WriteLine("       Tabela de multiplicação      ");
Console.WriteLine("================================");
for (int i = 1; i <= n; i++){
    for (int j = 1; j <= i; j++){
        Console.Write(" " + j * i + " ");
    }
    Console.WriteLine();
}
#endregion
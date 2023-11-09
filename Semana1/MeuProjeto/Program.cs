// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World 5!");

#region Teste do Tipo de Dados 
    int tipoInteiro;
    double tipoDouble;
    string tipoString;
    long tipoLong;

    tipoInteiro = int.MaxValue;
    tipoDouble = double.MaxValue;
    tipoLong = long.MaxValue;
    Console.WriteLine("O maximo inteiro é: " + tipoInteiro);
    Console.WriteLine("O máximo double: " + tipoDouble);
    Console.WriteLine("O máximo long: " + tipoLong);

    tipoString = "100";
    tipoInteiro = int.Parse(tipoString);
    Console.WriteLine("O valor de inteiro: ", tipoInteiro);
#endregion

#region  Operadores
    tipoDouble = tipoInteiro + tipoLong;
    //tipoInteiro = tipoDouble + tipoLong;
    //tipoLong = tipoDouble + tipoInteiro;
    tipoInteiro = 10 > 5 ? 1 : 6;
#endregion
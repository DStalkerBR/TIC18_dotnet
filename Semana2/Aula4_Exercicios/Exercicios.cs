// Suponha que você tenha uma string contendo uma data no formato
// "dd/mm/aaaa" (por exemplo, "25/10/2023"). Crie um programa que divida a
// string em dia, mês e ano e exiba cada parte separadamente.

#region  Separando Data
    string data = "25/10/2023";

    string[] dataArray = data.Split('/');

    Console.WriteLine("================================");
    Console.WriteLine("          String de Data        ");
    Console.WriteLine("================================");

    Console.WriteLine("Dia: " + dataArray[0]);
    Console.WriteLine("Mês: " + dataArray[1]);
    Console.WriteLine("Ano: " + dataArray[2]);
#endregion

// Crie um programa que inicialize um array de inteiros com números de 1 a 10.
// Em seguida, itere pelo array e exiba apenas os números pares.

#region Numeros Pares
    int[] numeros = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

    Console.WriteLine("================================");
    Console.WriteLine("     Numeros Pares (1..10)      ");
    Console.WriteLine("================================");

    foreach (int numero in numeros)
    {
        if (numero % 2 == 0)
        {
            Console.WriteLine(numero);
        }
    }
#endregion

// Crie uma lista de strings contendo nomes de cidades. Adicione mais
// algumas cidades a essa lista. Em seguida, crie um programa que itere pela
// lista e exiba todas as cidades cujos nomes começam com a letra "S".

#region
    List<string> cidades = new List<string>()
    {
        "Itabuna",
        "Ilheus",
        "Salvador"
    };
    cidades.Add("Itacaré");
    cidades.Add("Porto Seguro");
    cidades.Add("Santarém");
    cidades.Add("Santa Maria");

    Console.WriteLine("================================");
    Console.WriteLine("       Cidades com S          ");
    Console.WriteLine("================================");

    foreach (string cidade in cidades)
    {
        if (cidade.StartsWith("S"))
        {
            Console.WriteLine(cidade);
        }
    }

#endregion


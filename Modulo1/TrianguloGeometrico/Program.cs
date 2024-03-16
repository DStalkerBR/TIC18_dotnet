using TrianguloGeometrico;

public class Program {
    public static void Main() {
        Triangulo<int> trianguloInt = new Triangulo<int>(){
            P1 = new Ponto<int> { X = 1, Y = 2, Z = 3 },
            P2 = new Ponto<int> { X = 4, Y = 5, Z = 6 },
            P3 = new Ponto<int> { X = 7, Y = 8, Z = 9 }
        };


        Triangulo<double> trianguloDouble = new Triangulo<double>
        {
            P1 = new Ponto<double> { X = 1.1, Y = 2.2, Z = 3.3 },
            P2 = new Ponto<double> { X = 4.4, Y = 5.5, Z = 6.6 },
            P3 = new Ponto<double> { X = 7.7, Y = 8.8, Z = 9.9 }
        };

        Console.WriteLine("Coordenadas dos pontos do triângulo com inteiros: ");
        Console.WriteLine(trianguloInt.ToString());

        Console.WriteLine();
        Console.WriteLine("Coordenadas dos pontos do triângulo com double: ");
        Console.WriteLine(trianguloDouble.ToString());

    }
}

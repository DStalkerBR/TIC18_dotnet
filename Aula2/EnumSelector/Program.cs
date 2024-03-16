namespace EnumSelector;

class Program
{
    enum Exercicio
    {
        Academia = 1,
        Luta = 2,
        Corrida = 3
    }

    public static void Main()
    {
        Console.WriteLine("Opções de exercícios disponíveis:");

        foreach (Exercicio exercicio in Enum.GetValues(typeof(Exercicio)))
        {
            Console.WriteLine($"{(int)exercicio}. {exercicio}");
        }

        Console.WriteLine("Digite o número do exercício desejado:");
        
        string? input = Console.ReadLine();

        try
        {
            int numeroExercicio = int.Parse(input!);
            var exercicioEscolhido = (Exercicio)numeroExercicio;

            if (!Enum.IsDefined(typeof(Exercicio), exercicioEscolhido))
            {
                throw new ArgumentException();
            }

            Console.WriteLine($"Exercício escolhido: {exercicioEscolhido}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Digite um número válido.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Erro: Digite um número correspondente a um exercício válido.");
        }
    }
}

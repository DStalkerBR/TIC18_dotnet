using Model;

Lampada lampada = new Lampada(true);

int opcao = -1;

do
{
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine("1 - Ligar");
    Console.WriteLine("2 - Desligar");
    Console.WriteLine("0 - Sair");
    opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            lampada.Ligar();
            break;
        case 2:
            lampada.Desligar();
            break;
        case 0:
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    if (opcao != 0)
        lampada.Imprimir();
} while (opcao != 0);

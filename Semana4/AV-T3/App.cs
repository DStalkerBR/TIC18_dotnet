using Pessoa;

namespace dotNET_AV_T3;
public static class App
{
    public static List<Advogado> CriaAdvogados()
    {
        List<Advogado> advogados = new List<Advogado>();
        advogados.Add(new Advogado("João", "12345678901", new DateTime(1980, 1, 1), "123456"));
        advogados.Add(new Advogado("Maria", "23456789012", new DateTime(1985, 2, 2), "234567"));
        advogados.Add(new Advogado("José", "34567890123", new DateTime(1990, 3, 3), "345678"));
        advogados.Add(new Advogado("Ana", "45678901234", new DateTime(1995, 4, 4), "456789"));
        advogados.Add(new Advogado("Pedro", "56789012345", new DateTime(2000, 5, 5), "567890"));
        return advogados;
    }

    public static List<Cliente> CriaClientes()
    {
        List<Cliente> clientes = new List<Cliente>();
        clientes.Add(new Cliente("João", "12345678901", new DateTime(1980, 1, 1), "Casado", "Advogado"));
        clientes.Add(new Cliente("Maria", "23456789012", new DateTime(1985, 2, 2), "Solteiro", "Médico"));
        clientes.Add(new Cliente("José", "34567890123", new DateTime(1990, 3, 3), "Casado", "Engenheiro"));
        clientes.Add(new Cliente("Ana", "45678901234", new DateTime(1995, 4, 4), "Solteiro", "Professor"));
        clientes.Add(new Cliente("Pedro", "56789012345", new DateTime(2000, 5, 5), "Casado", "Advogado"));
        return clientes;
    }

    public static List<Cliente> CadastraCliente()
    {
        List<Cliente> clientes = new List<Cliente>();
        string? nome;
        string? cpf;
        string? estadoCivil;
        string? profissao;
        Console.Clear();
        Console.WriteLine("Cadastro de Cliente");
        Console.Write("Nome: ");
        if (string.IsNullOrEmpty(nome = Console.ReadLine()))
        {
            throw new Exception("Nome inválido!");
        }
        Console.Write("CPF: ");

        if (string.IsNullOrEmpty(cpf = Console.ReadLine())){
            throw new Exception("CPF inválido!");
        }

        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            throw new Exception("CPF inválido!");
        }

        if (clientes.Any(cliente => cliente.Cpf == cpf))
        {
            throw new Exception("CPF já cadastrado!");
        }

        Console.Write("Data de Nascimento: ");
        DateTime dataNascimento = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        
        Console.Write("Estado Civil: ");
        if (string.IsNullOrEmpty(estadoCivil = Console.ReadLine())){
            throw new Exception("Estado civil vazio!");
        }

        Console.Write("Profissão: ");
        if (string.IsNullOrEmpty(profissao = Console.ReadLine())){
            throw new Exception("Profissão vazia!");
        }
        clientes.Add(new Cliente(nome, cpf, dataNascimento, estadoCivil, profissao));
        Console.WriteLine("Cliente cadastrado com sucesso!");
        return clientes;
    }

    public static List<Advogado> CriarAdvogado (){
        Console.Clear();
        Console.WriteLine("Cadastro de Advogado");
        Console.Write("Nome: ");




    }
    

}

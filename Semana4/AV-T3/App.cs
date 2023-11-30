using Pessoa;

namespace dotNET_AV_T3;
public static class App
{
    public static List<Advogado> CriaAdvogados()
    {
        List<Advogado> advogados = new List<Advogado>();
        advogados.Add(new Advogado("João Andrade", "12345678901", new DateTime(1980, 1, 1), "123456"));
        advogados.Add(new Advogado("Maria Silva", "23456789012", new DateTime(1985, 2, 2), "234567"));
        advogados.Add(new Advogado("José Carlos", "34567890123", new DateTime(1990, 3, 3), "345678"));
        advogados.Add(new Advogado("Ana Maria", "45678901234", new DateTime(1995, 4, 4), "456789"));
        advogados.Add(new Advogado("Pedro Souza", "56789012345", new DateTime(2000, 5, 5), "567890"));
        return advogados;
    }

    public static List<Cliente> CriaClientes()
    {
        List<Cliente> clientes = new List<Cliente>();
        clientes.Add(new Cliente("John Smith", "12345678901", new DateTime(1980, 1, 1), "Casado", "Advogado"));
        clientes.Add(new Cliente("Manuela Alves", "23456789012", new DateTime(1985, 2, 2), "Solteiro", "Médico"));
        clientes.Add(new Cliente("Ze Sergio", "34567890123", new DateTime(1990, 3, 3), "Casado", "Engenheiro"));
        clientes.Add(new Cliente("Abigail Marques", "45678901234", new DateTime(1995, 4, 4), "Solteiro", "Professor"));
        clientes.Add(new Cliente("Antonio Pereira", "56789012345", new DateTime(2000, 5, 5), "Casado", "Advogado"));
        return clientes;
    }

    public static void CadastraCliente(List<Cliente> clientes)
    {
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
        App.PressioneQualquerTecla();
    }

    public static void CadastraAdvogado (List<Advogado> advogados){
        string? nome;
        string? cpf;
        string? cna;
        DateTime dataNascimento;
        Console.Clear();
        Console.WriteLine("Cadastro de Advogado");
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

        if (advogados.Any(advogado => advogado.Cpf == cpf))
        {
            throw new Exception("CPF já cadastrado!");
        }

        Console.Write("Data de Nascimento: ");
        dataNascimento = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        Console.Write("CNA: ");
        if (string.IsNullOrEmpty(cna = Console.ReadLine())){
            throw new Exception("CNA vazio!");
        }

        if (advogados.Any(advogado => advogado.Cna == cna))
        {
            throw new Exception("CNA já cadastrado!");
        }

        advogados.Add(new Advogado(nome, cpf, dataNascimento, cna));
        Console.WriteLine("Advogado cadastrado com sucesso!");
        App.PressioneQualquerTecla();
    }

    public static void ListaClientes(List<Cliente> clientes)
    {
        Console.Clear();
        Console.WriteLine("Lista de Clientes");
        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine(cliente.ToString());
        }
        App.PressioneQualquerTecla();
    }

    public static void ListaAdvogados(List<Advogado> advogados)
    {
        Console.Clear();
        Console.WriteLine("Lista de Advogados");
        foreach (Advogado advogado in advogados)
        {
            Console.WriteLine(advogado.ToString());
        }
        App.PressioneQualquerTecla();
    }

    public static void RelatorioAdvogadosIdade(List<Advogado> advogados){
        Console.Clear();
        Console.WriteLine("Relatório de Advogados por Idade");
        Console.Write("Idade mínima: ");
        int idadeMinima = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Idade máxima: ");
        int idadeMaxima = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        if (idadeMinima > idadeMaxima)
        {
            throw new Exception("Idade mínima não pode ser maior que idade máxima!");
        }
        if (idadeMinima < 0 || idadeMaxima < 0)
        {
            throw new Exception("Idade mínima e máxima devem ser positivas!");
        }

        IEnumerable<Advogado> advogados1;
        Func<List<Advogado>, int, int, List<Advogado>> porIdade;
        porIdade = (advogados, idadeMinima, idadeMaxima) => advogados
                                    .Where(advogado => advogado.Idade >= idadeMinima && advogado.Idade <= idadeMaxima)
                                    .ToList();
        advogados1 = porIdade(advogados, idadeMinima, idadeMaxima);
        Console.WriteLine("Advogados com idade entre {0} e {1} anos:", idadeMinima, idadeMaxima);
        Console.WriteLine(string.Join("\n\n", advogados1.Select(advogado => advogado.ToString())));    
        PressioneQualquerTecla();
    }

    public static void RelatorioClientesIdade(List<Cliente> clientes){
        Console.Clear();
        Console.WriteLine("Relatório de Clientes por Idade");
        Console.Write("Idade mínima: ");
        int idadeMinima = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Idade máxima: ");
        int idadeMaxima = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        if (idadeMinima > idadeMaxima)
        {
            throw new Exception("Idade mínima não pode ser maior que idade máxima!");
        }
        if (idadeMinima < 0 || idadeMaxima < 0)
        {
            throw new Exception("Idade mínima e máxima devem ser positivas!");
        }

        IEnumerable<Cliente> clientes1;
        Func<List<Cliente>, int, int, List<Cliente>> porIdade;
        porIdade = (clientes, idadeMinima, idadeMaxima) => clientes
                                    .Where(cliente => cliente.Idade >= idadeMinima && cliente.Idade <= idadeMaxima)
                                    .ToList();
        clientes1 = porIdade(clientes, idadeMinima, idadeMaxima);
        Console.WriteLine("Clientes com idade entre {0} e {1} anos:", idadeMinima, idadeMaxima);
        Console.WriteLine(string.Join("\n\n", clientes1.Select(cliente => cliente.ToString())));    
        PressioneQualquerTecla();
    }

    public static void RelatorioClientesEstadoCivil(List<Cliente> clientes){
        Console.Clear();
        Console.WriteLine("Relatório de Clientes por Estado Civil");
        Console.Write("Estado Civil: ");
        string estadoCivil = Console.ReadLine() ?? throw new InvalidOperationException();
        if (string.IsNullOrEmpty(estadoCivil))
        {
            throw new Exception("Estado civil inválido!");
        }

        IEnumerable<Cliente> clientes1;
        Func<List<Cliente>, string, List<Cliente>> porEstadoCivil;
        porEstadoCivil = (clientes, estadoCivil) => clientes
                                    .Where(cliente => cliente.EstadoCivil == estadoCivil)
                                    .ToList();
        clientes1 = porEstadoCivil(clientes, estadoCivil);
        Console.WriteLine("Clientes com estado civil {0}:", estadoCivil);
        Console.WriteLine(string.Join("\n\n", clientes1.Select(cliente => cliente.ToString())));
        PressioneQualquerTecla();
    }

    public static void RelatorioClientesOrdemAlfabetica (List<Cliente> clientes){
        Console.Clear();
        Console.WriteLine("Relatório de Clientes em Ordem Alfabética");
        List<Cliente> clientes1;
        Func<List<Cliente>, List<Cliente>> porOrdemAlfabetica;
        porOrdemAlfabetica = (clientes) => clientes
                                    .OrderBy(cliente => cliente.Nome)
                                    .ToList();
        clientes1 = porOrdemAlfabetica(clientes);
        Console.WriteLine("Clientes em ordem alfabética:");
        Console.WriteLine(string.Join("\n\n", clientes1.Select(cliente => cliente.ToString())));
        PressioneQualquerTecla();
    }

    public static void RelatorioClientesProfissao(List<Cliente> clientes){
        Console.Clear();
        Console.WriteLine("Relatório de Clientes por Profissão");
        Console.Write("Profissão: ");
        string profissao = Console.ReadLine() ?? throw new InvalidOperationException();
        if (string.IsNullOrEmpty(profissao))
        {
            throw new Exception("Profissão inválida!");
        }
        List<Cliente> clientes1;
        Func<List<Cliente>, string, List<Cliente>> porProfissao;
        porProfissao = (clientes, profissao) => clientes
                                    .Where(cliente => cliente.Profissao == profissao)
                                    .ToList();
        clientes1 = porProfissao(clientes, profissao);
        Console.WriteLine("Clientes com profissão {0}:", profissao);
        Console.WriteLine(string.Join("\n\n", clientes1.Select(cliente => cliente.ToString())));
        PressioneQualquerTecla();
    }

    public static void RelatorioAniversariantes(List<Cliente> clientes, List<Advogado> advogados){
        Console.Clear();
        Console.WriteLine("Relatório de Aniversariantes");
        Console.Write("Mês: ");
        int mes = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        if (mes < 1 || mes > 12)
        {
            throw new Exception("Mês inválido!");
        }
        List<Cliente> clientes1;
        List<Advogado> advogados1;
        Func<List<Cliente>, int, List<Cliente>> clientePorAniversario;
        Func<List<Advogado>, int, List<Advogado>> advogadoPorAniversario;
        clientePorAniversario = (clientes, mes) => clientes
                                    .Where(cliente => cliente.DataNascimento.Month == mes)
                                    .ToList();
        advogadoPorAniversario = (advogados, mes) => advogados
                                    .Where(advogado => advogado.DataNascimento.Month == mes)
                                    .ToList();
        clientes1 = clientePorAniversario(clientes, mes);
        advogados1 = advogadoPorAniversario(advogados, mes);
        Console.WriteLine("Clientes aniversariantes do mês {0}:", mes);
        Console.WriteLine(string.Join("\n\n", clientes1.Select(cliente => cliente.ToString())));
        Console.WriteLine("Advogados aniversariantes do mês {0}:", mes);
        Console.WriteLine(string.Join("\n\n", advogados1.Select(advogado => advogado.ToString())));
        PressioneQualquerTecla();


    }
    
    public static void PressioneQualquerTecla()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

}

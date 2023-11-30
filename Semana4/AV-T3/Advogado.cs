namespace Pessoa;
public class Advogado : Pessoa
{
    private string cna;
    private List<Cliente> clientes;

    public string Cna {
        get { return cna; }
        set { 
            if (value == null) throw new Exception("CNA não pode ser nulo");
            cna = value;
        }
    }

    public List<Cliente> Clientes {
        get { return clientes; }
        set { 
            if (value == null) throw new Exception("Lista de clientes não pode ser nula");
            clientes = value;
        }
    }

    public void AdicionaCliente(Cliente cliente) {
        Clientes.Add(cliente);
    }

    public Advogado(string nome, string cpf, DateTime dataNascimento, string cna) {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Cna = cna;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\nCPF: {Cpf}\nData de Nascimento: {DataNascimento.Date}\nCNA: {Cna}";
    }
}

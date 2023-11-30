namespace Pessoa;
public class Processo
{
    private string numero;
    private string descricao;
    private DateTime dataInicio;
    private DateTime? dataFim;
    private Cliente cliente;
    private Advogado advogado;

    public string Numero {
        get { return numero; }
        set { 
            if (value == null) throw new Exception("Número não pode ser nulo");
            numero = value;
        }
    }

    public string Descricao {
        get { return descricao; }
        set { 
            if (value == null) throw new Exception("Descrição não pode ser nula");
            descricao = value;
        }
    }

    public DateTime DataInicio {
        get { return dataInicio; }
        set { 
            if (value < DateTime.Now) {
                dataInicio = value;
            } else {
                throw new Exception("Data de início deve ser anterior à data atual");
            }
        }
    }

    public DateTime? DataFim {
        get { return dataFim; }
        set { 
            if (value < DateTime.Now) {
                dataFim = value;
            } else {
                throw new Exception("Data de fim deve ser anterior à data atual");
            }
        }
    }

    public Cliente Cliente {
        get { return cliente; }
        set { 
            if (value == null) throw new Exception("Cliente não pode ser nulo");
            cliente = value;
        }
    }

    public Advogado Advogado {
        get { return advogado; }
        set { 
            if (value == null) throw new Exception("Advogado não pode ser nulo");
            advogado = value;
        }
    }

    public Processo(string numero, string descricao, DateTime dataInicio, DateTime? dataFim, Cliente cliente, Advogado advogado) {
        Numero = numero;
        Descricao = descricao;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Cliente = cliente;
        Advogado = advogado;
        advogado.AdicionaCliente(cliente);
    }

    public override string ToString()
    {
        if (DataFim == null){
            return $"Número: {Numero}\nDescrição: {Descricao}\nData de Início: {DataInicio.Date}\nData de Fim: Aberto \nCliente: {Cliente.Nome}\nAdvogado: {Advogado.Nome}";
        }
        return $"Número: {Numero}\nDescrição: {Descricao}\nData de Início: {DataInicio.Date}\nData de Fim: {DataFim}\nCliente: {Cliente.Nome}\nAdvogado: {Advogado.Nome}";
    }
}

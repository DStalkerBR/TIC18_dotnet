namespace Pessoa;
public class Cliente : Pessoa
{
    private string estadoCivil;
    private string profissao;

    public string EstadoCivil {
        get { return estadoCivil; }
        set { 
            if (value == null) throw new Exception("Estado civil não pode ser nulo");
            estadoCivil = value;
        }
    }

    public string Profissao {
        get { return profissao; }
        set { 
            if (value == null) throw new Exception("Profissão não pode ser nula");
            profissao = value;
        }
    }   

}

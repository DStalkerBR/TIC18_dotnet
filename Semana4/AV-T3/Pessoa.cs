namespace Pessoa;
abstract class Pessoa
{
    private string cpf;
    private DateTime dataNascimento;

    public string? Nome {get; set;}

    public string Cpf {
        get { return cpf; }
        set { 
            if (value == null) throw new Exception("CPF não pode ser nulo");
            if (value.Length == 11) {
                cpf = value;
            } else {
                throw new Exception("CPF deve ter 11 dígitos");
            }
        }
    }

    public DateTime DataNascimento {
        get { return dataNascimento; }
        set { 
            if (value < DateTime.Now) {
                dataNascimento = value;
            } else {
                throw new Exception("Data de nascimento deve ser anterior à data atual");
            }
        }
    }

}

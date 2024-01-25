namespace TechMed.Core;

public class PacienteAlreadyExistsException : Exception
{
    public PacienteAlreadyExistsException() : base("Já existe um paciente com esse CRM cadastrado")
    {
    }
}

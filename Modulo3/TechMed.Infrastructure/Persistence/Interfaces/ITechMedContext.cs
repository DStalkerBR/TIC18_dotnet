namespace TechMed.Infrastructure.Persistence.Interfaces;
public interface ITechMedContext
{
    IMedicoCollection MedicoCollection { get; }
    IPacienteCollection PacienteCollection { get; }
    IExameCollection ExameCollection { get; }
    IAtendimentoCollection AtendimentoCollection { get; }
}

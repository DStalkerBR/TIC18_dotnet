namespace TechMed.WebAPI.Infra.Data.Interfaces;
public interface IDatabaseFake
{
    IMedicoCollection MedicoCollection { get; }
    IPacienteCollection PacienteCollection { get; }
    IExameCollection ExameCollection { get; }
    IAtendimentoCollection AtendimentoCollection { get; }
}

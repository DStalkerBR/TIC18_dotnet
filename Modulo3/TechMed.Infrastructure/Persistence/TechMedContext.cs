using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Infrastructure.Persistence;
public class TechMedContext : ITechMedContext
{
    public IMedicoCollection MedicoCollection { get; } = new MedicosDB();
    public IPacienteCollection PacienteCollection { get; } = new PacienteDB();
    public IAtendimentoCollection AtendimentoCollection { get; } = new AtendimentoDB();
    public IExameCollection ExameCollection { get; } = new ExameDB();
}

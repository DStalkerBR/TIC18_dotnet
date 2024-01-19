using TechMed.WebAPI.Infra.Data.Interfaces;

namespace TechMed.WebAPI.Infra.Data;
public class DatabaseFakeDB : IDatabaseFake
{
    public IMedicoCollection MedicoCollection { get; } = new MedicosDB();
    public IPacienteCollection PacienteCollection { get; } = new PacienteDB();
    public IAtendimentoCollection AtendimentoCollection { get; } = new AtendimentoDB();
    public IExameCollection ExameCollection { get; } = new ExameDB();
}

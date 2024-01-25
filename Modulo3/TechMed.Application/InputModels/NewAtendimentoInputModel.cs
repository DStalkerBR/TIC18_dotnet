using TechMed.Core.Entities;

namespace TechMed.Application.InputModels;

public class NewAtendimentoInputModel
{
    public DateTime DataHora { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
}

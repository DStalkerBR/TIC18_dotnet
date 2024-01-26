using TechMed.Core.Entities;

namespace TechMed.Application.ViewModels;

public class ExameViewModel
{
    public int ExameId { get; set; }
    public DateTime DataHora { get; set; }
    public string? Descricao { get; set; }
    public AtendimentoViewModel? Atendimento { get; set; }
}

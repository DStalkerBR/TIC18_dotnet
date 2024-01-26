namespace TechMed.Core.Entities;

public class Exame : BaseEntity
{
    public int ExameId { get; set; }
    public DateTime DataHora { get; set; }
    public string? Descricao { get; set; }
    public string? Resultado { get; set; }
    public int AtendimentoId { get; set; }
    public Atendimento? Atendimento { get; set; }
}

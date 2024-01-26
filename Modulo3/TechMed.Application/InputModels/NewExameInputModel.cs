namespace TechMed.Application.InputModels;

public class NewExameInputModel {
    public DateTime DataHora { get; set; }
    public string? Descricao { get; set; }
    public int AtendimentoId { get; set; }
}
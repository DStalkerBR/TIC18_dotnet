namespace TechMed.WebAPI.Model;
public class Exame
{
    public int ExameId { get; set; }
    public string Descricao { get; set; }
    public string Resultado { get; set; }
    public int AtendimentoId { get; set; }
    public Atendimento Atendimento { get; set; }
}

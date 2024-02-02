namespace CarBuilder.MinimalAPI;

public class LinhaMontagem
{
    public string? Chassi { get; set; }
    public string? Motor { get; set; }
    public string? Pintura { get; set; }
    public string? Interno { get; set; }
    public string? Portas { get; set; }

    public string toString() => $"Chassi: {Chassi}, Motor: {Motor}, Pintura: {Pintura}, Interno: {Interno}, Portas: {Portas}";
}

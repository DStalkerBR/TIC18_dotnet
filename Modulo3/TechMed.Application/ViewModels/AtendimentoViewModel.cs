﻿namespace TechMed.Application.ViewModels;

public class AtendimentoViewModel
{
    public int AtendimentoId { get; set; }
    public DateTime DataHora { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
    public string? NomeMedico { get; set; }
    public string? NomePaciente { get; set; }
}

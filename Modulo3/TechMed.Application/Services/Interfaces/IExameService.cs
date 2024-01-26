using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;

public interface IExameService
{
    public List<ExameViewModel> GetAll();
    public ExameViewModel? GetById(int exameId);
    // public List<ExameViewModel>? GetByPacienteId(int pacienteId);
    // public List<ExameViewModel>? GetByMedicoId(int medicoId);
    public int Create(NewExameInputModel exame);
}

using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;

public class PacienteService : IPacienteService
{
    private readonly ITechMedContext _context;

    public PacienteService(ITechMedContext context)
    {
        _context = context;
    }

    public int Create (NewPacienteInputModel paciente)
    {
        return _context.PacienteCollection.Create(new Paciente
        {
            Nome = paciente.Nome,
            CPF = paciente.CPF,
        });
    }

    public void Delete(int id)
    {
        _context.PacienteCollection.Delete(id);
    }

    public List<PacienteViewModel> GetAll()
    {
        var pacientes = _context.PacienteCollection.GetAll().Select(p => new PacienteViewModel
        {
            PacienteId = p.PacienteId,
            Nome = p.Nome,
            CPF = p.CPF,
        }).ToList();

        return pacientes;
    }

    public PacienteViewModel? GetByCpf(string cpf)
    {
        throw new NotImplementedException();
    }

    public PacienteViewModel? GetById(int id)
    {
        var paciente = _context.PacienteCollection.GetById(id);

        if (paciente is null)
            return null;

        var pacienteViewModel = new PacienteViewModel
        {
            PacienteId = paciente.PacienteId,
            Nome = paciente.Nome,
            CPF = paciente.CPF,
        };

        return pacienteViewModel;
    }

    public void Update(int id, NewPacienteInputModel paciente)
    {
        _context.PacienteCollection.Update(id, new Paciente
        {
            Nome = paciente.Nome,
            CPF = paciente.CPF,
        });
    }

}

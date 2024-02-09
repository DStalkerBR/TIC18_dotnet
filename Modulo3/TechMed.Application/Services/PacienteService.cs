using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence;
using TechMed.Core.Exceptions;

namespace TechMed.Application.Services;
public class PacienteService : IPacienteService
{
    private readonly TechMedDbContext _context;
    public PacienteService(TechMedDbContext context)
    {
        _context = context;
    }

    private Paciente GetByDbId(int id)
    {
        var paciente = _context.Pacientes.FirstOrDefault(m => m.PacienteId == id);
        if (paciente is null) 
            throw new PacienteNotFoundException();

        return paciente;
    }

    public int Create(NewPacienteInputModel medico)
    {
        var paciente = new Paciente
        {
            Nome = medico.Nome
        };
        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
        return paciente.PacienteId;
    }

    public void Delete(int id)
    {
        _context.Pacientes.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<PacienteViewModel> GetAll()
    {
        var _pacientes = _context.Pacientes.Select(m => new PacienteViewModel
        {
            PacienteId = m.PacienteId,
            Nome = m.Nome
        }).ToList();

        return _pacientes;
    }

    public PacienteViewModel? GetById(int id)
    {
        var _paciente = GetByDbId(id);

        var PacienteViewModel = new PacienteViewModel
        {
            PacienteId = _paciente.PacienteId,
            Nome = _paciente.Nome
        };
        return PacienteViewModel;
    }

    public void Update(int id, NewPacienteInputModel paciente)
    {
        var _paciente = GetByDbId(id);

        _paciente.Nome = paciente.Nome;

        _context.Pacientes.Update(_paciente);

        _context.SaveChanges();
    }
}

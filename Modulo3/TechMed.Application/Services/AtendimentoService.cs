using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;

public class AtendimentoService : IAtendimentoService
{
    private readonly ITechMedContext _context;

    public AtendimentoService(ITechMedContext context)
    {
        _context = context;
    }

    public int Create(NewAtendimentoInputModel atendimento)
    {
        return _context.AtendimentoCollection.Create(new Atendimento
        {
            DataHora = atendimento.DataHora,
            PacienteId = atendimento.PacienteId,
            MedicoId = atendimento.MedicoId,
            Medico = _context.MedicoCollection.GetById(atendimento.MedicoId) ?? throw new Exception("Medico não encontrado"),
            Paciente = _context.PacienteCollection.GetById(atendimento.PacienteId) ?? throw new Exception("Paciente não encontrado")
        });
    }

    public void Delete(int id)
    {
        _context.AtendimentoCollection.Delete(id);
    }

    public List<AtendimentoViewModel> GetAll()
    {
        var atendimentos = _context.AtendimentoCollection.GetAll().Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            PacienteId = a.PacienteId,
            NomePaciente = a.Paciente.Nome,
            MedicoId = a.MedicoId,
            NomeMedico = a.Medico.Nome,
            DataHora = a.DataHora
        }).ToList();

        return atendimentos;
    }

    public AtendimentoViewModel? GetById(int id)
    {
        var atendimento = _context.AtendimentoCollection.GetById(id);

        if (atendimento is null)
            return null;

        var atendimentoViewModel = new AtendimentoViewModel
        {
            AtendimentoId = atendimento.AtendimentoId,
            PacienteId = atendimento.PacienteId,
            MedicoId = atendimento.MedicoId,
            DataHora = atendimento.DataHora
        };
        return atendimentoViewModel;
    }
}

using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;

public class ExameService : IExameService
{
    private readonly ITechMedContext _context;

    public ExameService(ITechMedContext context)
    {
        _context = context;
    }

    public List<ExameViewModel> GetAll()
    {
        var exames = _context.ExamesCollection.GetAll().Select(e => new ExameViewModel
        {
            ExameId = e.ExameId,
            DataHora = e.DataHora,
            Descricao = e.Descricao,
            Atendimento = new AtendimentoViewModel
            {
                AtendimentoId = e.Atendimento.AtendimentoId,
                DataHora = e.Atendimento.DataHora,
                Medico = new MedicoViewModel
                {
                    MedicoId = e.Atendimento.Medico.MedicoId,
                    Nome = e.Atendimento.Medico.Nome
                },
                Paciente = new PacienteViewModel
                {
                    PacienteId = e.Atendimento.Paciente.PacienteId,
                    Nome = e.Atendimento.Paciente.Nome
                }
            }
        }).ToList();

        return exames;
    }

    public ExameViewModel? GetById(int exameId)
    {
        var exame = _context.ExamesCollection.GetById(exameId);

        if (exame is null)
            return null;

        var exameVM = new ExameViewModel
        {
            ExameId = exame.ExameId,
            DataHora = exame.DataHora,
            Descricao = exame.Descricao,
            Atendimento = new AtendimentoViewModel
            {
                AtendimentoId = exame.Atendimento.AtendimentoId,
                DataHora = exame.Atendimento.DataHora,
                Medico = new MedicoViewModel
                {
                    MedicoId = exame.Atendimento.Medico.MedicoId,
                    Nome = exame.Atendimento.Medico.Nome
                },
                Paciente = new PacienteViewModel
                {
                    PacienteId = exame.Atendimento.Paciente.PacienteId,
                    Nome = exame.Atendimento.Paciente.Nome
                }
            }
        };

        return exameVM;
    }

    public int Create(NewExameInputModel exame)
    {
        var exameDB = new Exame
        {
            DataHora = exame.DataHora,
            Descricao = exame.Descricao,
            AtendimentoId = exame.AtendimentoId,
            Atendimento = _context.AtendimentosCollection.GetById(exame.AtendimentoId)
        };

        return _context.ExamesCollection.Create(exameDB);
    }

}

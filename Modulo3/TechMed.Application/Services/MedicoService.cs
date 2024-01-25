using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;

public class MedicoService : IMedicoService
{
  private readonly ITechMedContext _context;
  public MedicoService(ITechMedContext context)
  {
    _context = context;
  }

  public int Create(NewMedicoInputModel medico)
  {
    return _context.MedicoCollection.Create(new Medico{
      Nome = medico.Nome
      });

  }

  public void Delete(int id)
  {
    _context.MedicoCollection.Delete(id);
  }

  public List<MedicoViewModel> GetAll()
  {
    var medicos = _context.MedicoCollection.GetAll().Select(m => new MedicoViewModel{
      MedicoId = m.MedicoId,
      Nome = m.Nome,
    }).ToList();

    return medicos;

  }

  public MedicoViewModel? GetByCrm(string crm)
  {
    throw new NotImplementedException();
  }

  public MedicoViewModel? GetById(int id)
  {
    var medico = _context.MedicoCollection.GetById(id);
    
    if(medico is null)
      return null;

    var MedicoViewModel = new MedicoViewModel{
      MedicoId = medico.MedicoId,
      Nome = medico.Nome
    };
    return MedicoViewModel;
  }

  public void Update(int id, NewMedicoInputModel medico)
  {
    _context.MedicoCollection.Update(id, new Medico{
      Nome = medico.Nome
    });
  }

  public void CreateAtendimento(int id, NewAtendimentoInputModel atendimento)
  {
    _context.AtendimentoCollection.Create(new Atendimento{
      DataHora = atendimento.DataHora,
      PacienteId = atendimento.PacienteId,
      MedicoId = id,
      Medico = _context.MedicoCollection.GetById(id) ?? throw new Exception("Medico não encontrado"),
      Paciente = _context.PacienteCollection.GetById(atendimento.PacienteId) ?? throw new Exception("Paciente não encontrado")
    });
  }
} 
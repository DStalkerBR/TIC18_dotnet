using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;
public class MedicoService : IMedicoService
{
  private readonly TechMedDbContext _context;
  public MedicoService(TechMedDbContext context)
  {
    _context = context;
  }

  public int Create(NewMedicoInputModel medico)
  {
    var _medico = new Medico
    {
      Nome = medico.Nome
    };

    _context.Medicos.Add(_medico);
    _context.SaveChanges();
    return _medico.MedicoId;
  }

  public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
  {
    var medico = GetByDbId(medicoId);
    if (medico is null)
      throw new MedicoNotFoundException();

    var paciente = _context.Pacientes.FirstOrDefault(p => p.PacienteId == atendimento.PacienteId);
    if (paciente is null)
      throw new PacienteNotFoundException();


    var atendimentoDb = new Atendimento
    {
      DataHora = atendimento.DataHora,
      Medico = medico,
      Paciente = paciente
    };

    _context.Atendimentos.Add(atendimentoDb);
    _context.SaveChanges();
    return atendimentoDb.AtendimentoId;    
  }

  public void Delete(int id)
  {
    _context.Medicos.Remove(GetByDbId(id));
  }

  public List<MedicoViewModel> GetAll()
  {
    var medicos = _context.Medicos.Select(m => new MedicoViewModel
    {
      MedicoId = m.MedicoId,
      Nome = m.Nome
    }).ToList();

    return medicos;

  }

  public MedicoViewModel? GetByCrm(string crm)
  {
    throw new NotImplementedException();
  }

  public MedicoViewModel? GetById(int id)
  {
    var medico = GetByDbId(id);

    if (medico is null)
      return null;

    var MedicoViewModel = new MedicoViewModel
    {
      MedicoId = medico.MedicoId,
      Nome = medico.Nome
    };
    return MedicoViewModel;
  }

  public void Update(int id, NewMedicoInputModel medico)
  {
    var _medico = GetByDbId(id);
    _medico.Nome = medico.Nome;
    _context.Medicos.Update(_medico);
    _context.SaveChanges();
  }

  private Medico GetByDbId(int id)
  {
    var medico = _context.Medicos.FirstOrDefault(m => m.MedicoId == id);
    if (medico is null)
      throw new MedicoNotFoundException();

    return medico;
  }
    
}

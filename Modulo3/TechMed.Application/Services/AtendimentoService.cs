using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Exceptions;
using TechMed.Infrastructure.Persistence;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;
public class AtendimentoService : IAtendimentoService
{  
   private readonly IMedicoService _medicoService;
   private readonly TechMedDbContext _context;
   public AtendimentoService(TechMedDbContext context, IMedicoService medico) 
   {
      _medicoService = medico;
      _context = context;
   }
   public int Create(NewAtendimentoInputModel atendimento){
      return _medicoService.CreateAtendimento(atendimento.MedicoId, atendimento);
   }
    public List<AtendimentoViewModel> GetAll()
   {
      return _context.Atendimentos.Select(a => new AtendimentoViewModel
      {
         AtendimentoId = a.AtendimentoId,
         DataHora = a.DataHora,
         Medico = new MedicoViewModel
         {
            MedicoId = a.Medico.MedicoId,
            Nome = a.Medico.Nome
         },
         Paciente = new PacienteViewModel
         {
            PacienteId = a.Paciente.PacienteId,
            Nome = a.Paciente.Nome
         }
      }).ToList();
   }

   public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
   {
      throw new NotImplementedException();
   }

   public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
   {
      throw new NotImplementedException();
   }
}

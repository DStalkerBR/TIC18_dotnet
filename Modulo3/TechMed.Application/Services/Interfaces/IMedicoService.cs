using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;

namespace TechMed.Application.Services.Interfaces;

public interface IMedicoService
{
      public List<MedicoViewModel> GetAll();
      public MedicoViewModel? GetById(int id);
      public MedicoViewModel? GetByCrm(string crm);
      public int Create(NewMedicoInputModel medico);
      public void Update(int id, NewMedicoInputModel medico);
      public void Delete(int id);
      void CreateAtendimento(int id, NewAtendimentoInputModel atendimento);
}

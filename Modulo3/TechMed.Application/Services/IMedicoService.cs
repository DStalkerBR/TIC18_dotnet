using TechMed.Application.InputModels;
using TechMed.Core.Entities;

namespace TechMed.Application.Services.Interfaces;

public interface IMedicoService
{
    public void Create (NewMedico medico);
    public void Update (Medico medico);
    public void Delete (Medico medico);
    public Medico GetById (int id);
    public Medico GetByCrm (int id);
    public IEnumerable<Medico> GetAll ();
}

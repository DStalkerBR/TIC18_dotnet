using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;

public class MedicoService : IMedicoService
{
    public MedicoService(ITechMedContext context)
    {
    }

    public void Create(NewMedico medico)
    {
        throw new NotImplementedException();
    }

    public void Delete(Medico medico)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Medico> GetAll()
    {
        throw new NotImplementedException();
    }

    public Medico GetByCrm(int id)
    {
        throw new NotImplementedException();
    }

    public Medico GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Medico medico)
    {
        throw new NotImplementedException();
    }

    public static OutMedico Map(Medico medico){
        return new OutMedico{
            MedicoId = medico.MedicoId,
            Nome = medico.Nome,
        };
    }

}
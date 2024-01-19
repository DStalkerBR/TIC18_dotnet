using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra.Data;
public class AtendimentoDB : IAtendimentoCollection
{
    private readonly List<Atendimento> _atendimentos = new List<Atendimento>();
    private int _id = 0; 

    public void Create(Atendimento atendimento)
    {
        if(_atendimentos.Count > 0)
            _id = _atendimentos.Max(a => a.AtendimentoId);
        atendimento.AtendimentoId = ++_id;
        _atendimentos.Add(atendimento);   
        
    }

    public void Delete(int id)
    {
        _atendimentos.RemoveAll(a => a.AtendimentoId == id);
    }

    public ICollection<Atendimento> GetAll()
    {
        return _atendimentos.ToArray();
    }

    public Atendimento? GetById(int id)
    {
        return _atendimentos.FirstOrDefault(a => a.AtendimentoId == id);
    }

    public void Update(int id, Atendimento atendimento)
    {
        var atendimentoDB = _atendimentos.FirstOrDefault(a => a.AtendimentoId == id);
        if(atendimentoDB is not null)
        {
            atendimentoDB.DataHora = atendimento.DataHora;
            atendimentoDB.MedicoId = atendimento.MedicoId;
            atendimentoDB.PacienteId = atendimento.PacienteId;
        }
    }

}

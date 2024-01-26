using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;

namespace TechMed.Infrastructure.Persistence;
public class ExamesDB : IExameCollection
{
    private readonly List<Exame> _exames = new();
    private int _id=  0;

    public int Create(Exame exame){
        if(_exames.Count > 0)
            _id = _exames.Max(e => e.ExameId);
        exame.ExameId = ++_id;
        _exames.Add(exame);
        return exame.ExameId;
    }

    public void Delete(int id){
        _exames.RemoveAll(e => e.ExameId == id);
    }

    public ICollection<Exame> GetAll(){
        return _exames.ToArray();
    }

    public Exame? GetById(int id){
        return _exames.FirstOrDefault(e => e.ExameId == id);
    }

    public void Update(int id, Exame exame){
        var exameDB = _exames.FirstOrDefault(e => e.ExameId == id);
        if(exameDB is not null){
            exameDB.Descricao = exame.Descricao;
            exameDB.Resultado = exame.Resultado;
            exameDB.AtendimentoId = exame.AtendimentoId;
        }
    }



}

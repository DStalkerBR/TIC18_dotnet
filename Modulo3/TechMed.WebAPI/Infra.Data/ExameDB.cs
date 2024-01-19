using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra.Data;
public class ExameDB : IExameCollection
{
    private readonly List<Exame> _exames = new();
    private int _id=  0;

    public void Create(Exame exame){
        if(_exames.Count > 0)
            _id = _exames.Max(e => e.ExameId);
        exame.ExameId = ++_id;
        _exames.Add(exame);
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

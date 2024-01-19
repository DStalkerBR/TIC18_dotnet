namespace TechMed.WebAPI.Infra.Data.Interfaces;
public interface IBaseCollection<T>
{
    void Create(T item);
    ICollection<T> GetAll();
    T? GetById(int id);
    void Update(int id, T item);
    void Delete(int id);
}

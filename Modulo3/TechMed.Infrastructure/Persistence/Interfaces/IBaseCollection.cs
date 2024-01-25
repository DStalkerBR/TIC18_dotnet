namespace TechMed.Infrastructure.Persistence.Interfaces;
public interface IBaseCollection<T>
{
    int Create(T item);
    ICollection<T> GetAll();
    T? GetById(int id);
    void Update(int id, T item);
    void Delete(int id);
}

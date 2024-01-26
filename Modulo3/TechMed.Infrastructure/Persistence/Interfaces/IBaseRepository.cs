namespace TechMed.Infrastructure.Persistence.Interfaces;

public interface IBaseRepository<T>
{
    void Create(T obj);
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    void Update(int id, T obj);
    void Delete(int id);
}

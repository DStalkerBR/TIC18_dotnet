using Microsoft.EntityFrameworkCore;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Infrastructure.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly TechMedDBContext _context;

    public BaseRepository(TechMedDBContext context)
    {
        _context = context;
    }

    public void Create(T obj)
    {
        _context.Set<T>().Add(obj);
        _context.SaveChanges();
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id) ?? throw new Exception($"Entidade com ID {id} nao encontrada.");
    }

    public void Update(int id, T obj)
    {
        _context.Set<T>().Update(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = _context.Set<T>().Find(id) ?? throw new Exception($"Entidade com ID {id} nao encontrada.");
        _context.Set<T>().Remove(obj);
        _context.SaveChanges();
    }

}

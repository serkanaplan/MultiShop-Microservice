using Cargo.Repository.Abstract;
using Cargo.Repository.Concrete;

namespace Cargo.Repository.Repositories;

public class GenericRepository<T>(CargoContext context) : IGenericDal<T> where T : class
{
    private readonly CargoContext _context = context;

    public void Delete(int id)
    {
        var values = _context.Set<T>().Find(id);
        _context.Set<T>().Remove(values);
        _context.SaveChanges();
    }
    public List<T> GetAll() => [.. _context.Set<T>()];
    public T GetById(int id) => _context.Set<T>().Find(id);
   
    public void Insert(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }
   
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}

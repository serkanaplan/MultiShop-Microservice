using Microsoft.EntityFrameworkCore;
using Order.Application.Interfaces;
using Order.Persistence.Context;
using System.Linq.Expressions;

namespace Order.Persistence.Repositories;

public class Repository<T>(OrderContext context) : IRepository<T> where T : class
{
    private readonly OrderContext _context = context;

    public async Task CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(filter);
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}

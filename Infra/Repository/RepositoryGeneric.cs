using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
{
    private readonly Contexto _context;
    public RepositoryGeneric(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task Add(T objeto)
    {
        _context.Set<T>().Add(objeto);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T objeto)
    {
        _context.Set<T>().Remove(objeto);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetEntityById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> List()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }
    public async Task Update(T objeto)
    {
        _context.Set<T>().Update(objeto);
        await _context.SaveChangesAsync();
    }

    private bool disposedValue;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                
            }

            
            disposedValue = true;
        }
    }
    public void Dispose()
    {
        
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

   
}

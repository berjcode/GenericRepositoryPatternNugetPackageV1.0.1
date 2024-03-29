﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GenericRepository.Library.Concrete;

public class GenericRepositoryAsync<T, TContext> : IRepositoryAsync<T>
    where T : class
    where TContext : DbContext
{
    #region Fields
    private DbSet<T> Entity;
    private readonly TContext _context;
    #endregion

    private static readonly Func<TContext, bool, Task<T>> GetFirstCompiled =
     EF.CompileAsyncQuery((TContext context, bool isTracking) =>
     isTracking == true ? context.Set<T>().FirstOrDefault()
     : context.Set<T>().AsNoTracking().FirstOrDefault());


    #region Ctor
    public GenericRepositoryAsync(TContext context)
    {
        _context = context;
        Entity = _context.Set<T>();
    }
    #endregion

    #region Methods
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
    }

    public async Task AddRamgeAsync(ICollection<T> entities, CancellationToken cancellationToken = default)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }

    public async Task AddRangeAsync(IList<T> entities, CancellationToken cancellationToken = default)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);

    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }

    public void Delete(T entity)
    {
        Entity.Remove(entity);
    }

    public async Task DeleteByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        T entity = await Entity.Where(expression).FirstOrDefaultAsync(cancellationToken);
        Entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(int id)
    {
        T entity = await Entity.FindAsync(id);
        Entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(string id)
    {
        T entity = await Entity.FindAsync(id);
        Entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        T entity = await Entity.FindAsync(id);
        Entity.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        Entity.RemoveRange(entities);
    }

    public void DeleteRange(ICollection<T> entities)
    {
        Entity.RemoveRange(entities);
    }

    public void DeleteRange(IList<T> entities)
    {
        Entity.RemoveRange(entities);
    }

    public IQueryable<T> GetAll(bool isTracking = true)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }

    public IEnumerable<T> GetAllEnumerable(bool isTracking = true)
    {
        var result = Entity.AsEnumerable();
        if (!isTracking)
        {
            result = Entity.AsNoTracking().AsEnumerable();

            return result;
        }

        return result;
    }

    public IList<T> GetAllWithList(bool isTracking = true)
    {
        var result = Entity.ToList();
        if (!isTracking)
        {
            result = Entity.AsNoTracking().ToList();

            return result;
        }

        return result;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var result = Entity.Where(expression).AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }
    public IList<T> GetWhereList(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var result = Entity.Where(expression).ToList();
        if (!isTracking)
        {
            result = Entity.Where(expression).AsNoTracking().ToList();
            return result;
        }

        return result;
    }
    public async Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true, CancellationToken cancellationToken = default)
    {
        T entity = null;
        if (isTracking)
        {
            entity = await Entity.Where(expression).FirstOrDefaultAsync(cancellationToken);
        }
        else
        {
            entity = await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        return entity;
    }



    public async Task<T> GetFirstAsync(bool isTracking = true)
    {
        T entity = null;
        if (isTracking)
        {
            entity = await Entity.FirstOrDefaultAsync();
        }
        else
        {
            entity = await Entity.AsNoTracking().FirstOrDefaultAsync();
        }

        return entity;
    }

    public async Task<T> GetFirstAsync(bool isTracking, CancellationToken cancellationToken)
    {
        T entity = null;
        if (isTracking)
        {
            entity = await Entity.FirstOrDefaultAsync(cancellationToken);
        }
        else
        {
            entity = await Entity.AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        return entity;
    }

    public void Update(T entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(ICollection<T> entities)
    {
        Entity.UpdateRange(entities);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        Entity.UpdateRange(entities);
    }
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await Entity.AnyAsync(predicate);
    }
    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
    {
        return await (predicate == null ? Entity.CountAsync() : Entity.CountAsync(predicate));
    }
    public IQueryable<T> GetAllExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var result = Entity.Where(expression).AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();

        return result;
    }
    public IReadOnlyList<T> GetAllReadOnlyList(bool isTracking = true)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();

        return result.ToList().AsReadOnly();
    }
    public async Task<T> GetFirstCompiledQuery(bool isTracking = false)
    {
        return await GetFirstCompiled(_context, isTracking);
    }
    #endregion
}

﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace GenericRepository.Library.Concrete;

public class GenericRepository<T, TContext> : IRepository<T>
    where T : class
    where TContext : DbContext
{
    private readonly TContext _context;
    private DbSet<T> Entity;

    public GenericRepository(TContext context, DbSet<T> entity)
    {
        _context = context;
        Entity = entity;
    }

    public void Add(T entity)
    {
        Entity.AddAsync(entity);
    }

    public void AddRange(ICollection<T> entities)
    {
        Entity.AddRange(entities);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        Entity.AddRange(entities);
    }

    public void AddRange(IList<T> entities)
    {
        Entity.AddRange(entities);
    }

    public void Delete(T entity)
    {
        Entity.Remove(entity);
    }

    public T DeleteByExpression(Expression<Func<T, bool>> expression)
    {
        var entity = Entity.Where(expression).FirstOrDefault(expression);
        if (entity != null)
        {
            Entity.Remove(entity);
            return entity;
        }
        return null;
    }

    public T DeleteById(int id)
    {
        var entity = Entity.Find(id);
        if (entity != null)
        {
            Entity.Remove(entity);
            return entity;
        }

        return null;
    }

    public T DeleteById(string id)
    {
        var entity = Entity.Find(id);
        if (entity != null)
        {
            Entity.Remove(entity);
            return entity;
        }

        return null;
    }

    public T DeleteById(Guid id)
    {
        var entity = Entity.Find(id);
        if (entity != null)
        {
            Entity.Remove(entity);
            return entity;
        }

        return null;
    }

    public void DeleteRange(ICollection<T> entities)
    {
        Entity.RemoveRange(entities);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        Entity.RemoveRange(entities);
    }

    public void DeleteRange(IList<T> entities)
    {
        Entity.RemoveRange(entities);
    }

    public IQueryable<T> GetAll(bool isTracking = false)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();
        return result;
    }

    public IEnumerable<T> GetAllV2(bool isTracking = false)
    {
        var result = Entity.AsEnumerable();
        if (!isTracking)
        {
            result = Entity.AsNoTracking().AsEnumerable();
            return result;
        }

        return result;
    }

    public IList<T> GetAllV3(bool isTracking = false)
    {
        var result = Entity.ToList();
        if (!isTracking)
        {
            result = Entity.AsNoTracking().ToList();
            return result;
        }

        return result;
    }

    public T GetByExpression(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        T entity = null;
        if (isTracking)
        {
            entity = Entity.Where(expression).FirstOrDefault();
        }
        else
        {
            entity = Entity.Where(expression).AsNoTracking().FirstOrDefault();
        }
        return entity;
    }

    public T GetFirst(bool isTracking = false)
    {
        T entity = null;
        if (isTracking)
        {
            entity = Entity.FirstOrDefault();
        }
        else
        {
            entity = Entity.AsNoTracking().FirstOrDefault();
        }

        return entity;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();
        return result;
    }

    public IList<T> GetWhereV2(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        var result = Entity.ToList();
        if (!isTracking)
        {
            result = Entity.AsNoTracking().ToList();
            return result;
        }

        return result;
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

    public void UpdateRange(IList<T> entities)
    {
        Entity.UpdateRange(entities);
    }
}
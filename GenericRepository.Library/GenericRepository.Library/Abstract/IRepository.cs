using System.Linq.Expressions;

namespace GenericRepository.Library;

/// <summary>
/// Any entity can be given. T has to be a class.
/// </summary>
public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll(bool isTracking = true);
    IQueryable<T> GetAllExpression(Expression<Func<T, bool>> expression, bool isTracking = true);
    IEnumerable<T> GetAllEnumerable(bool isTracking = true);
    IList<T> GetAllWithList(bool isTracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
    IList<T> GetWhereWithList(Expression<Func<T, bool>> expression, bool isTracking = true);
    T GetFirstByExpression(Expression<Func<T, bool>> expression, bool isTracking = true);
    T GetFirst(bool isTracking = true);
    bool Any(Expression<Func<T, bool>> predicate);
    int Count(Expression<Func<T, bool>> predicate = null);
    void Add(T entity);
    void AddRange(ICollection<T> entities);
    void AddRange(IEnumerable<T> entities);
    void AddRange(IList<T> entities);
    void Update(T entity);
    void UpdateRange(ICollection<T> entities);
    void UpdateRange(IEnumerable<T> entities);
    void UpdateRange(IList<T> entities);
    T DeleteById(int id);
    T DeleteById(string id);
    T DeleteById(Guid id);
    T DeleteByExpression(Expression<Func<T, bool>> expression);
    void Delete(T entity);
    void DeleteRange(ICollection<T> entities);
    void DeleteRange(IEnumerable<T> entities);
    void DeleteRange(IList<T> entities);
}

using System.Linq.Expressions;

namespace GenericRepository.Library;

/// <summary>
/// Any entity can be given. T has to be a class.
/// </summary>
public interface IRepository<T> where T : class
{
    // Query
    T GetFirst(bool isTracking = true);
    IQueryable<T> GetAll(bool isTracking = true);
    bool Any(Expression<Func<T, bool>> predicate);
    IList<T> GetAllWithList(bool isTracking = true);
    int Count(Expression<Func<T, bool>> predicate = null);
    IEnumerable<T> GetAllEnumerable(bool isTracking = true);
    IReadOnlyList<T> GetAllReadOnlyList(bool isTracking =true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
    T GetFirstByExpression(Expression<Func<T, bool>> expression, bool isTracking = true);
    IList<T> GetWhereWithList(Expression<Func<T, bool>> expression, bool isTracking = true);
    IQueryable<T> GetAllExpression(Expression<Func<T, bool>> expression, bool isTracking = true);
    // Command
    void Add(T entity);
    void Update(T entity);
    T DeleteById(int id);
    void Delete(T entity);
    T DeleteById(Guid id);
    T DeleteById(string id);
    void AddRange(IList<T> entities);
    void UpdateRange(IList<T> entities);
    void DeleteRange(IList<T> entities);
    void AddRange(IEnumerable<T> entities);
    void AddRange(ICollection<T> entities);
    void UpdateRange(ICollection<T> entities);
    void UpdateRange(IEnumerable<T> entities);
    void DeleteRange(ICollection<T> entities);
    void DeleteRange(IEnumerable<T> entities);
    T DeleteByExpression(Expression<Func<T, bool>> expression);
}

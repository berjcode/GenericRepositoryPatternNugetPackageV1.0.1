using System.Linq.Expressions;

namespace GenericRepository.Library;

/// <summary>
/// Any entity can be given. T has to be a class.  It includes asynchronous methods.
/// </summary>
public interface IRepositoryAsync<T> where T : class
{
    // Query
    IQueryable<T> GetAll(bool isTracking = true);
    Task<T> GetFirstAsync(bool isTracking = true);
    IList<T> GetAllWithList(bool isTracking = true);
    Task<T> GetFirstCompiledQuery(bool isTracking = false);
    IEnumerable<T> GetAllEnumerable(bool isTracking = true);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    IReadOnlyList<T> GetAllReadOnlyList(bool isTracking = true);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    Task<T> GetFirstAsync(bool isTracking, CancellationToken cancellationToken);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
    IList<T> GetWhereList(Expression<Func<T, bool>> expression, bool isTracking = true);
    IQueryable<T> GetAllExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true);
    Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true, CancellationToken cancellationToken = default);
   // Command
    void Update(T entity);
    void Delete(T entity);
    Task DeleteByIdAsync(int id);
    Task DeleteByIdAsync(Guid id);
    Task DeleteByIdAsync(string id);
    void DeleteRange(IList<T> entities);
    void DeleteRange(ICollection<T> entities);
    void DeleteRange(IEnumerable<T> entities);
    void UpdateRange(ICollection<T> entities);
    void UpdateRange(IEnumerable<T> entities);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IList<T> entities, CancellationToken cancellationToken = default);
    Task AddRamgeAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task DeleteByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}

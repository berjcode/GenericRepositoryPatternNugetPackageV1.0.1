using System.Linq.Expressions;

namespace GenericRepository.Library;

public interface IRepositoryAsync<T> where T : class
{
    IQueryable<T> GetAll(bool isTracking = true);
    IQueryable<T> GetAllExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true);
    IEnumerable<T> GetAllEnumerable(bool isTracking = true);
    IList<T> GetAllWithList(bool isTracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
    IList<T> GetWhereList(Expression<Func<T, bool>> expression, bool isTracking = true);
    Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true, CancellationToken cancellationToken = default);
    Task<T> GetFirstAsync(bool isTracking = true);
    Task<T> GetFirstAsync(bool isTracking, CancellationToken cancellationToken);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task AddRamgeAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IList<T> entities, CancellationToken cancellationToken = default);
    void Update(T entity);
    void UpdateRange(ICollection<T> entities);
    void UpdateRange(IEnumerable<T> entities);
    Task DeleteByIdAsync(int id);
    Task DeleteByIdAsync(string id);
    Task DeleteByIdAsync(Guid id);
    Task DeleteByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    void DeleteRange(ICollection<T> entities);
    void DeleteRange(IList<T> entities);






}

namespace GenericRepository.Library;

/// <summary>
/// It provides transaction management.
/// </summary>
public interface IUnitOfWork
{
    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken);
}

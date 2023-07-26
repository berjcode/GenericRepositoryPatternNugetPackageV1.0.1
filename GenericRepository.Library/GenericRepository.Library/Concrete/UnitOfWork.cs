using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Library.Concrete;

/// <summary>
/// It provides transaction management.
/// </summary>
public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    #region Fields
    private readonly TContext _context;
    #endregion

    #region Ctor
    public UnitOfWork(TContext context)
    {
        _context = context;
    }
    #endregion

    #region Methods
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    #endregion
}

# Feature

"Hello, I would like to talk about the features of GenericRepositoryPattern, a NuGet package I wrote. This package, besides providing a more comfortable use by using the GenericRepository pattern, makes database operations easier by coming with the UnitOfWork pattern."
* You can work with the unitOfWork Design Pattern.
* You can work with asynchronous or non-asynchronous methods.
* Overloads of methods are available.
* AsNotracking() can be given as a parameter.
* CancellationToken can be given as a parameter.
* More methods will be added.


Errors are corrected as a result of feedback.

# GenericRepositoryPatternNugetPackageV1.2
 A nuget package I wrote to use the generic repository pattern more efficiently.
# Version
.net 7.0
# Install
```

  dotnet add package GenericRepositoryandUnitOfWorkPattern --version 1.2
```
# Use 
##Create Repository
```
//Interface- Abstract 
public interface IProductRepositoryAsync : IRepositoryAsync<Product> {} 

  //Concrete  
  public class ProductRepositoryAsync : GenericRepositoryAsync<Product, ExampleDbContext>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(ExampleDbContext context) : base(context) {}
            
        
   }


```
## Create Controller 
```
    private readonly IProductRepositoryAsync _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IProductRepositoryAsync repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

....
## Create Method - Controller
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        IList<Product> product = await _repository.GetAll().ToListAsync(cancellationToken);
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> Add(Product product, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

     return Ok();
    }
```

## Warning
   * Dependency Injection
   ```
   //Program.cs && ExtensionServices
  builder.Services.AddScoped<IUnitOfWork, UnitOfWork<ExampleDbContext>>();
  builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
   ```
## Packages

* EntityFramework Core 7.0.11

 ### Design Patterns:
    * Generic Repository   
    * Unit Of Work    
                                                                                                                     
   ###    By Abdullah Balikci - berjcode

      
       
  ## IRepositoryAsync Methods

   ```
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

   ```

  ## IRepository

   ```
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
   ```

 

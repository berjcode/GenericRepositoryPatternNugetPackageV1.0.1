# Feature

[![MIT License][license-shield]][license-url]

"Hello, I would like to talk about the features of GenericRepositoryPattern, a NuGet package I wrote. This package, besides providing a more comfortable use by using the GenericRepository pattern, makes database operations easier by coming with the UnitOfWork pattern."
* You can work with the unitOfWork Design Pattern.
* You can work with asynchronous or non-asynchronous methods.
* Overloads of methods are available.
* AsNotracking() can be given as a parameter.
* CancellationToken can be given as a parameter.
* More methods will be added.


Errors are corrected as a result of feedback.

# GenericRepositoryPatternNugetPackageV1.1.2
 A nuget package I wrote to use the generic repository pattern more efficiently.
# Version
.net 7.0
# Install
```

  dotnet add package GenericRepositoryandUnitOfWorkPattern --version 1.1.2
```
# Use 
## Create Repository
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

* EntityFramework Core 7.0.5

 ### Design Patterns:
    * Generic Repository   
    * Unit Of Work    
      
       
  ## IRepositoryAsync Methods

   ```
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

   ```

  ## IRepository

   ```
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
   ```

[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/berjcode/GenericRepositoryPatternNugetPackageV1.0.1/blob/main/LICENSE
                                                                                                                      
   ###    By Abdullah Balikci - berjcode


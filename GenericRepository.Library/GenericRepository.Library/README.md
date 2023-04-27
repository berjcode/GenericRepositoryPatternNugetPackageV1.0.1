# Feature

"Hello, I would like to talk about the features of GenericRepositoryPattern, a NuGet package I wrote. This package, besides providing a more comfortable use by using the GenericRepository pattern, makes database operations easier by coming with the UnitOfWork pattern."
* You can work with the unitOfWork Design Pattern.
* You can work with asynchronous or non-asynchronous methods.
* Overloads of methods are available.
* AsNotracking() can be given as a parameter.
* CancellationToken can be given as a parameter.
* More methods will be added.

# GenericRepositoryPatternNugetPackageV1.0.1
 A nuget package I wrote to use the generic repository pattern more efficiently.
# Version
.net 7.0
# Install
 * dotnet add package EntityFrameworkCore.GenericRepository.Nuget 

# Use 
##Create Repository
```
public interface IProductRepository : IRepositoryasync<Product> &&  IRepository<Product>
public class ProductRepository : Repository<Product, MyContext> ,IProductRepository
```
## Create Service
```

public interface IProductService{
    Task AddAsync(Product product, CancellationToken cancellationToken);
     void  AddAsync(Product product, CancellationToken cancellationToken);
}
public class ProductService : IProductService
{


 private readonly IProductRepository _productRepository;
 private readonly IUnitOfWork _unitOfWork;
 public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

....
## Create Method
public async Task AddAsync(Product product, CancellationToken cancellationToken)
{
    await _userRepository.AddAsync(product, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
}

public void  AddAsync(Product product)
{
     _userRepository.Add(product );
     _unitOfWork.SaveChangesAsync();
}
 

}
```


## Warning
   * Dependency Injection
   ```
   //Program.cs && ExtensionServices
   services.AddScoped<IUnitOfWork, UnitOfWork<ProjectDbContext>>();
   services.AddScoped<IProductRepository, ProductRepository>();
   ```
## Packages

* EntityFramework Core 5.x


 ### Design Patterns:
    * Generic Repository   
    * Unit Of Work    
                                                                                                                     
   ###    By Abdullah Balikci - berjcode

      
       
  

 

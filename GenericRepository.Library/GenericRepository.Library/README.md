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
##Create Service
```
public class ProductService : IProductService
{


private readonly IProductRepository _productRepository;
private readonly IUnitOfWork _unitOfWork;

....

public async Task AddAsync(Product product, CancellationToken cancellationToken)
{
    await _userRepository.AddAsync(product, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
}
 

}
```


## Warning
   * Dependency Injection
   ```
   //Program.cs && ExtensionServices
   builder.Service.AddScoped<IUnitOfWork, UnitOfWok<MyDbContext>>();
   ```
## Packages

* EntityFramework Core 5.x


 ### Design Patterns:
      * Generic Repository   
       * Unit Of Work    
                                                                                                                     
     

      
       
  

 

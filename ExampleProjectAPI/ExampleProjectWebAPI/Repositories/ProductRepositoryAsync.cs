using ExampleProjectWebAPI.Context;
using ExampleProjectWebAPI.Entities;
using GenericRepository.Library.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ExampleProjectWebAPI.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product, ExampleDbContext>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(ExampleDbContext context) : base(context, context.Set<Product>())
        {
            
        }
    }
}

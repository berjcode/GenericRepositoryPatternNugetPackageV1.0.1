
using ExampleProject.Entities;
using GenericRepository.Library.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Repositories;

public sealed class ProductRepository : GenericRepository<Product, ProjectDbContext>, IProductRepository
{
    public ProductRepository(ProjectDbContext context, DbSet<Product> entity) : base(context, entity)
    {
    }
}

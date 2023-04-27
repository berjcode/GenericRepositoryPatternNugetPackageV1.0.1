using ExampleProjectWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleProjectWebAPI.Context;

public class ExampleDbContext :DbContext
{

    public ExampleDbContext()
    {

    }
    public ExampleDbContext(DbContextOptions options) : base(options) { }
  


    public DbSet<Product> Products { get; set; }
}

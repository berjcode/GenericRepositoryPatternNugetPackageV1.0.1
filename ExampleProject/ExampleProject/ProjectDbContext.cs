

using ExampleProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExampleProject;

public sealed class ProjectDbContext:DbContext
{


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       

       optionsBuilder.UseSqlServer("Data Source=berjcode; Initial Catalog=exampleProject ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
    }


    public DbSet<Product> Products { get; set; }


}

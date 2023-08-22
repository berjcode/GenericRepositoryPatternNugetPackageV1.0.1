using Microsoft.EntityFrameworkCore;
using GenericRepository.UnitTest.ItemsRequiredForTesting.Entities;

namespace GenericRepository.UnitTest.ItemsRequiredForTesting;

public class TestDbContext :DbContext
{
    public DbSet<ProductEntity> Products { get; set; }
}

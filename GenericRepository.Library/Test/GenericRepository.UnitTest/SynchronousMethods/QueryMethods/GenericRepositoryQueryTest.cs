using GenericRepository.Library.Concrete;
using GenericRepository.UnitTest.ItemsRequiredForTesting.Entities;
using GenericRepository.UnitTest.ItemsRequiredForTesting;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GenericRepository.UnitTest.SynchronousMethods.QueryMethods;

public class GenericRepositoryQueryTest
{
    [Fact]
    public void Count_WithPredicate_ReturnsCorrectCount()
    {
        var data = new List<ProductEntity>
        {
            new ProductEntity {Id=1, Name="Product 1"},
            new ProductEntity {Id=2, Name="Product 2"},
            new ProductEntity {Id=3, Name="Product 3"},
            new ProductEntity {Id=4, Name="Product 4"}
        }.AsQueryable();

        var mockDbSet = new Mock<DbSet<ProductEntity>>();
        mockDbSet.As<IQueryable<ProductEntity>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<ProductEntity>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<ProductEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<ProductEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<TestDbContext>();
        mockContext.Setup(c => c.Set<ProductEntity>()).Returns(mockDbSet.Object);

        var repository = new GenericRepository<ProductEntity, TestDbContext>(mockContext.Object);

        // Act
        var count = repository.Count(p => p.Id > 1);

        // Assert
        Assert.Equal(3, count);
    }

}
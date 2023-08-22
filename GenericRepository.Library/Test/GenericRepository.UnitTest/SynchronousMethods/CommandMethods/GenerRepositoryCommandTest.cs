using GenericRepository.Library.Concrete;
using GenericRepository.UnitTest.ItemsRequiredForTesting;
using GenericRepository.UnitTest.ItemsRequiredForTesting.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Xml;
using Xunit;

namespace GenericRepository.UnitTest.SynchronousMethods.CommandMethods;

public  class GenerRepositoryCommandTest
{

    [Fact]
    public void Add_Entity_AddsSuccessfully()
    {
        //Arrange
        var mockDbSet = new Mock<DbSet<ProductEntity>>();
        mockDbSet.Setup(m => m.AddAsync(It.IsAny<ProductEntity>(), It.IsAny<CancellationToken>()))
                 .Callback<ProductEntity, CancellationToken>((entity, _) => mockDbSet.Object.Add(entity));

        var mockContext = new Mock<TestDbContext>();
        mockContext.Setup(c => c.Set<ProductEntity>()).Returns(mockDbSet.Object);

        var repository = new GenericRepository<ProductEntity, TestDbContext>(mockContext.Object);
        var entity = new ProductEntity { Id = 1, Name = "Test Entity" };

        // Act
        repository.Add(entity);

        // Assert
        mockDbSet.Verify(m => m.AddAsync(entity, It.IsAny<CancellationToken>()), Times.Once);

    }
    [Fact]
    public void DeleteById_EntityExists_RemovesSuccessfully()
    {
        // Arrange
        var mockDbSet = new Mock<DbSet<ProductEntity>>();
        var entityToDelete = new ProductEntity { Id = 1, Name = "Abdullah" };

        mockDbSet.Setup(m => m.Find(It.IsAny<int>())).Returns(entityToDelete);

        var mockContext = new Mock<TestDbContext>();
        mockContext.Setup(c => c.Set<ProductEntity>()).Returns(mockDbSet.Object);

        var repository = new GenericRepository<ProductEntity, TestDbContext>(mockContext.Object);

        // Act
        var deletedEntity = repository.DeleteById(1);

        // Assert
        mockDbSet.Verify(m => m.Find(1), Times.Once);
        mockDbSet.Verify(m => m.Remove(It.IsAny<ProductEntity>()), Times.Once); 
        Assert.NotNull(deletedEntity);
    }

    [Fact]
    public void DeleteById_EntityIsNull_DoesNotRemove()
    {
        // Arrange
        var mockDbSet = new Mock<DbSet<ProductEntity>>();
        var entityToDelete = (ProductEntity)null;

        mockDbSet.Setup(m => m.Find(It.IsAny<int>())).Returns(entityToDelete);

        var mockContext = new Mock<TestDbContext>();
        mockContext.Setup(c => c.Set<ProductEntity>()).Returns(mockDbSet.Object);

        var repository = new GenericRepository<ProductEntity, TestDbContext>(mockContext.Object);

        // Act
        var deletedEntity = repository.DeleteById(1);

        // Assert
        mockDbSet.Verify(m => m.Find(1), Times.Once);
        mockDbSet.Verify(m => m.Remove(It.IsAny<ProductEntity>()), Times.Never); 
        Assert.Null(deletedEntity);
    }

   
}

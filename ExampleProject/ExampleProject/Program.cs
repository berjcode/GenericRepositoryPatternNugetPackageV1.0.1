
using ExampleProject;
using ExampleProject.Repositories;
using GenericRepository.Library;
using GenericRepository.Library.Concrete;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public Program(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
   
        services.AddScoped<IUnitOfWork, UnitOfWork<ProjectDbContext>>();
        services.AddScoped<IProductRepository, ProductRepository>();





        Console.WriteLine("Hello, World!");

        //_productRepository.Add(product);
        //_unitOfWork.SaveChanges();
    }


   
}
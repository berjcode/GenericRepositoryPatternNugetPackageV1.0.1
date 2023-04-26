
using ExampleProject;
using Microsoft.Extensions.DependencyInjection;
using System;
using GenericRepository.Library;
using GenericRepository.Library.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddScoped<IUnitOfWork, UnitOfWork<ProjectDbContext>>();


        Console.WriteLine("Hello, World!");
    }
}
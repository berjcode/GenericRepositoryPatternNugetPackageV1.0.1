using ExampleProjectWebAPI.Entities;
using ExampleProjectWebAPI.Repositories;
using GenericRepository.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleProjectWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly IProductRepositoryAsync _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IProductRepositoryAsync repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        IList<Product> product = await _repository.GetAll().ToListAsync(cancellationToken);
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> Add(Product product, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

     return Ok();
    }

}


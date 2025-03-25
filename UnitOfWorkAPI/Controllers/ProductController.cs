using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkAPI.DataAccess.Context;
using UnitOfWorkAPI.Domain.Entities;
using UnitOfWorkAPI.Domain.Repository;

namespace UnitOfWorkAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : BaseApiController<Product>
{
    public ProductController(
    UowDbContext context,
    IConfiguration configuration,
    IUnitOfWork unitOfWork)
    : base(context, configuration, unitOfWork)
    {
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _context.Product.Include(x => x.Brand).ToList();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var products = _context.Product.Include(x => x.Brand).Where(x => x.Id == id).ToList();
        return Ok(products);
    }
    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _unitOfWork.Product.Add(product);
        _unitOfWork.Save();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        if (id != product.Id)
            return BadRequest(new { message = "ID'ler eşleşmiyor." });

        var productd = _unitOfWork.Product.GetById(id);
        if (productd == null)
            return NotFound(new { message = "Ürün bulunamadı." });

        productd.Name = product.Name;
        productd.Description = product.Description;
        productd.Sku = product.Sku;
        productd.Price = product.Price;
        productd.Barcode = product.Barcode;
        productd.Status = product.Status;
        productd.BrandId = product.BrandId;
        _unitOfWork.Save();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _unitOfWork.Product.GetById(id);
        if (success != null)
            return NotFound(new { message = "Ürün bulunamadı." });

        _unitOfWork.Product.Remove(success);
        _unitOfWork.Save();
        return NoContent();
    }
}

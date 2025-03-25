using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkAPI.DataAccess.Context;
using UnitOfWorkAPI.Domain.Entities;
using UnitOfWorkAPI.Domain.Repository;

namespace UnitOfWorkAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandController : BaseApiController<Brand>
{
    public BrandController(
    UowDbContext context,
    IConfiguration configuration,
    IUnitOfWork unitOfWork)
    : base(context, configuration, unitOfWork)
    {
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var brands = _unitOfWork.Brand.GetAll();
        return Ok(brands);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var brands = _unitOfWork.Brand.GetById(id);
        return Ok(brands);
    }
    [HttpPost]
    public IActionResult Create([FromBody] Brand brand)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _unitOfWork.Brand.Add(brand);
        _unitOfWork.Save();
        return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Brand brand)
    {
        if (id != brand.Id)
            return BadRequest(new { message = "ID'ler eşleşmiyor." });

        var brandd = _unitOfWork.Brand.GetById(id);
        if (brandd == null)
            return NotFound(new { message = "Marka bulunamadı." });

        brandd.Name = brand.Name;
        _unitOfWork.Save();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _unitOfWork.Brand.GetById(id);
        if (success != null)
            return NotFound(new { message = "Marka bulunamadı." });

        _unitOfWork.Brand.Remove(success);
        _unitOfWork.Save();
        return NoContent();
    }
}

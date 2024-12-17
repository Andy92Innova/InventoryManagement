using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace InventoryManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id){
        var product = await _productService.GetProductByIdAsync(id);
        if(product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Product product)
    {
        await _productService.AddProductAsync(product);
        return CreatedAtAction(nameof(GetById), new { Id=product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Product product)
    {
        if(id == Guid.Empty || id != product.Id)
            return BadRequest();
        
        await _productService.UpdateProductAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}
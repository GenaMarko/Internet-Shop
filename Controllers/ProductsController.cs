using Internet_Shop.Models;
using Internet_Shop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Shop.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var created = await _service.CreateAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if(product == null) return NotFound();

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id,Product product)
        {
            var updated = await _service.UpdateAsync(id, product);

            if(updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if(!deleted) return NotFound();

            return NoContent();
        }
    }
}

using Domain.Dto;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? name, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var products = await _service.GetProductsAsync(name!, page, pageSize);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve data: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var product = await _service.CreateProductAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to create product: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var message = await _service.DeleteProductAsync(id);

                if (message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                    return NotFound(message);

                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete product: {ex.Message}");
            }
        }

    }
}

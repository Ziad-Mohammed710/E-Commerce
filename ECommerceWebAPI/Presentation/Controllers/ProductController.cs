using ECommerceWebAPI.Application.Services;
using ECommerceWebAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerceWebAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService ??
                throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts(
                [FromQuery] int pageNumber = 1,
                [FromQuery] int pageSize = 10,
                [FromQuery] string sortBy = "Id",
                [FromQuery] bool ascending = true,
                [FromQuery] string? keyword = null)
        {
            try
            {
                var pagedProducts = await _productService.GetProductsAsync(keyword,
                                                                sortBy, ascending,
                                                                pageNumber, pageSize);

                return Ok(pagedProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var addedProduct = await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = addedProduct.Id }, addedProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            try
            {
                await _productService.UpdateProductAsync(product);
            }
            catch (Exception)
            {
                if (await _productService.GetProductByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var existingProduct = await _productService.GetProductByIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound(); // Return NotFound if product with ID doesn't exist
                }

                await _productService.DeleteProductAsync(id);
                return Ok($"Product with ID {id} was deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
    }
}

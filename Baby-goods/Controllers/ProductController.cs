using Baby_goods.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetProductById(string id)
        {
            var result = await _productService.GetById(id);

            return Ok(result);
        }

        [HttpGet("priceRange/{priceRange}")]
        public async Task<IActionResult> GetProductsByPriceRange(string priceRange)
        {
            var result = await _productService.GetByPriceRange(priceRange);

            return Ok(result);
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            var result = await _productService.GetByCategory(category);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByFilter([FromQuery] string? category, [FromQuery] string? price)
        {
            var result = await _productService.GetByFilter(category, price);

            return Ok(result);
        }
    }
}

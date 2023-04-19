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

        [HttpGet("article/{article}")]
        public async Task<IActionResult> GetProductByArticle(string article)
        {
            if (!Product.IsArticle(article))
            {
                return BadRequest();
            }

            var result = await _productService.GetByArticle(article);
            
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

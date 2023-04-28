using Baby_goods.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.Get());
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Get(Guid categoryId)
        {
            return Ok(await _categoryService.Get(categoryId));
        }
    }
}

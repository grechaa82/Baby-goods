using Baby_goods.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pageIndex = 0;
            var pageSize = 20;

            var products = await _homeService.Get(pageIndex, pageSize);
            
            return Ok(products);
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var products = await _homeService.Get(pageIndex, pageSize);

            return Ok(products);
        }
    }
}

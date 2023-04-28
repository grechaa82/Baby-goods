using Baby_goods.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("userId/addressId")]
        public async Task<IActionResult> CreateOrder(Guid userId, Guid addressId)
        {
            await _orderService.Create(userId, addressId);
            return Ok();
        }
    }
}

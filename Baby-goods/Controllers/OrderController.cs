using Baby_goods.Common.Interfaces;
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

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetOrder()
        {
            var order = await _orderService.GetOrder();

            return Ok(order);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetOrderItem()
        {
            var orderItems = await _orderService.GetOrderItem();

            return Ok(orderItems);
        }
    }
}

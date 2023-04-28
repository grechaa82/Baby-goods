using Baby_goods.Common.Interfaces.Services;
using Baby_goods.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/shoppingCart")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public ShoppingCartController(IShoppingCartItemService shoppingCartItemService)
        {
            _shoppingCartItemService = shoppingCartItemService;
        }

        [HttpGet("{userId}/items")]
        public async Task<IActionResult> GetShoppingCart(Guid userId)
        {
            List<ShoppingCartItem> result = await _shoppingCartItemService.Get(userId);
            return Ok(result);
        }

        [HttpGet("{userId}/cost")]
        public async Task<IActionResult> GetCost(Guid userId)
        {
            var cost = await _shoppingCartItemService.GetCost(userId);
            return Ok(cost);
        }

        [HttpGet("{userId}/numberOfProducts")]
        public async Task<IActionResult> GetNumberOfProducts(Guid userId)
        {
            var numberOfProducts = await _shoppingCartItemService.GetNumberOfProducts(userId);
            return Ok(numberOfProducts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingCartItem(Guid productId, Guid userId)
        {
            if (await _shoppingCartItemService.Create(productId, userId))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{shoppingCartItemId}/{quantity:int}")]
        public async Task<IActionResult> SetQuantity(Guid shoppingCartItemId, int quantity)
        {
            await _shoppingCartItemService.SetQuantity(shoppingCartItemId, quantity);
            return Ok();
        }

        [HttpDelete("{shoppingCartItemId}")]
        public async Task<IActionResult> DeleteShoppingCartItem(Guid shoppingCartItemId)
        {
            if (await _shoppingCartItemService.Delete(shoppingCartItemId))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}

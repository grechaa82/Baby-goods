using Baby_goods.Common.Interfaces.Services;
using Baby_goods.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            var address = await _addressService.Get(id);
            return Ok(address);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAddressesByUserId(Guid userId)
        {
            var addresses = await _addressService.GetByUserId(userId);

            return Ok(addresses);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateAdress(Guid userId, AddressRequest request)
        {
            await _addressService.Create(
                userId,
                request.City,
                request.Country,
                request.AddressLine1,
                request.AddressLine2,
                request.AddressLine3,
                request.AddressLine4);

            return Ok();
        }

        [HttpPut("{id}/city")]
        public async Task<IActionResult> UpdateCity(Guid id, string city)
        {
            try
            {
                await _addressService.UpdateCity(id, city);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/country")]
        public async Task<IActionResult> UpdateCountry(Guid id, string country)
        {
            try
            {
                await _addressService.UpdateCountry(id, country);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/addressLines")]
        public async Task<IActionResult> UpdateAddressLines(
            Guid id, 
            string addressLine1,
            string addressLine2,
            string addressLine3,
            string addressLine4)
        {
            try
            {
                await _addressService.UpdateAddressLines(id, addressLine1, addressLine2, addressLine3, addressLine4);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _addressService.Delete(id);
            return Ok();
        }
    }
}

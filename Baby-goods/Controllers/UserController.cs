using Baby_goods.BL;
using Baby_goods.Common.Interfaces;
using Baby_goods.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration(UserRegistrationRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                return BadRequest("Passwords don't matchю.");
            }

            var user = await _userService.GetByEmail(request.Email);
            if (user != null)
            {
                return BadRequest("The user already exists.");
            }

            var newUser = new User(
                request.Username,
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName,
                request.Phone);

            await _userService.Create(newUser);

            return Ok();
        }
    }
}

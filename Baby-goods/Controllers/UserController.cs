using Baby_goods.Common.Interfaces;
using Baby_goods.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetById(id);

             return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> Registration(UserRegistrationRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                return BadRequest("Passwords don't match.");
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

        [HttpPut("{id}/password")]
        public async Task<IActionResult> UpdatePassword(Guid id, string password)
        {
            try
            {
                await _userService.UpdatePassword(id, password);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/username")]
        public async Task<IActionResult> UpdateUsername(Guid id, string newUsername)
        {
            try
            {
                await _userService.UpdateUsername(id, newUsername);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/firstNameAndLastName")]
        public async Task<IActionResult> UpdateFirstNameAndLastName(Guid id, string firstName, string lastName)
        {
            try
            {
                await _userService.UpdateFirstNameAndLastName(id, firstName, lastName);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/phone")]
        public async Task<IActionResult> UpdatePhone(Guid id, string phone)
        {
            try
            {
                await _userService.UpdatePhone(id, phone);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

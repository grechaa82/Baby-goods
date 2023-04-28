using Baby_goods.Common.Interfaces.Services;
using Baby_goods.Contracts;
using Baby_goods.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Baby_goods.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly JwtOptions _jwtOptions;

        public AuthController(IOptions<JwtOptions> jwtOptions, IUserService userService)
        {
            _userService = userService;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userService.GetByEmail(request.Email);

            if (user == null)
            {
                return BadRequest("There is no such user.");
            }
            if (user.Password != request.Password)
            {
                return BadRequest("Invalid password.");
            }

            var tokenString = GenerateJwtToken(user.Id.ToString(), user.Username);

            return Ok(new { Token = tokenString });
        }

        private string GenerateJwtToken(string id, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiryInMinutes),
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

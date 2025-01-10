using CreditCardManager.Models.Auth;
using CreditCardManager.Services.JWTs;
using CreditCardManager.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IJwtService jwtService, IUserService userService) : ControllerBase
    {
        private readonly IJwtService _jwtService = jwtService;
        private readonly IUserService _userService = userService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.AuthenticateAsync(request);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = await _userService.RegisterUserAsync(request);

            if (user == null)
            {
                return Conflict(new { Message = "An error occurred while creating the user. Please try again later."});
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}

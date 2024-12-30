using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Lógica para autenticar al usuario
            return Ok(new { message = "Login successful" });
        }
    }
}

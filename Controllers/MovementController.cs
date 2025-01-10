using CreditCardManager.Models.Movement;
using CreditCardManager.Services.Movements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovementController(IMovementService movementService) : ControllerBase
    {
        private readonly IMovementService _movementService = movementService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovementById([FromRoute] int id)
        {
            var movement = await _movementService.GetMovementByIdAsync(id);
            if (movement == null)
            {
                return NotFound(new { message = "Movement not found" });
            }
            return Ok(movement);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MovementRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdMovement = await _movementService.CreateMovementAsync(request);
            return CreatedAtAction(nameof(Add), new { id = createdMovement.Id }, createdMovement);
        }
    }
}

using CreditCardManager.Models.Movement;
using CreditCardManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly MovementService _movementService;

        public MovementController(MovementService movementService)
        {
            _movementService = movementService;
        }

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

            var movement = new Movement
            {
                Card = request.Card,
                Amount = request.Amount,
                InstallmentsQty = request.InstallmentsQty,
                Date = DateOnly.Parse(request.Date),
                Detail = request.Detail,
                Payer = request.Payer,
                Observations = request.Observations
            };

            var createdMovement = await _movementService.AddMovementAsync(movement);
            return CreatedAtAction(nameof(GetMovementById), new { id = createdMovement.Id }, createdMovement);
        }
    }
}

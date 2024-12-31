using CreditCardManager.Models.Movement;
using CreditCardManager.Services.Movements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;

        public MovementController(IMovementService movementService)
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
                Card = request.Card ?? string.Empty,
                Amount = request.Amount,
                InstallmentsQty = request.InstallmentsQty,
                Date = DateOnly.TryParse(request.Date, out var parsedDate) ? parsedDate : DateOnly.FromDateTime(DateTime.Now),
                Detail = request.Detail ?? string.Empty,
                Payer = request.Payer ?? string.Empty,
                Observations = request.Observations ?? string.Empty
            };

            var createdMovement = await _movementService.AddMovementAsync(movement);
            return CreatedAtAction(nameof(GetMovementById), new { id = createdMovement.Id }, createdMovement);
        }
    }
}

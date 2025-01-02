using CreditCardManager.Services.Cards;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CreditCardManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById([FromRoute] int id)
        {
            var card = await _cardService.GetCardByIdAsync(id);
            if (card == null)
            {
                return NotFound(new { message = "Card not found" });
            }
            return Ok(card);
        }
    }
}

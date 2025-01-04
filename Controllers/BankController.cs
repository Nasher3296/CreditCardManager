using CreditCardManager.Models.Banks;
using CreditCardManager.Services.Banks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditBankManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankById([FromRoute] int id)
        {
            var bank = await _bankService.GetBankByIdAsync(id);
            if (bank == null)
            {
                return NotFound(new { message = "Bank not found" });
            }
            return Ok(bank);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BankRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBank = await _bankService.CreateBankAsync(request);
            return CreatedAtAction(nameof(Add), new { id = createdBank.Id }, createdBank);
        }
    }
}

﻿using CreditCardManager.Services.Movements;
using CreditCardManager.Services.Payers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayerController : ControllerBase
    {
        private readonly IPayerService _payerService;

        public PayerController(IPayerService payerService)
        {
            _payerService = payerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayerById([FromRoute] int id)
        {
            var payer = await _payerService.GetPayerByIdAsync(id);
            if (payer == null)
            {
                return NotFound(new { message = "Payer not found" });
            }
            return Ok(payer);
        }
    }
}
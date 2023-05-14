using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentManagement.Api.Services.Dtos;
using PaymentManagement.Api.Services.Implementation;
using PaymentManagement.Api.Services.Interface;

namespace PaymentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService){
            _paymentService = paymentService;
        }

        [HttpPost ("make-payment")]   
        public async Task<IActionResult> CreatePayment( [FromBody] PaymentDto paymentDto){
            if(!ModelState.IsValid){
                return BadRequest("Invalid Model state");
            }
            var result = await _paymentService.CreatePaymentAsync( paymentDto);
            return Ok(result);
        }

        [HttpGet("Verify-Payment")]        
        public async Task<IActionResult> VerifyPayment([FromQuery]string userId)
        {
            var result = await _paymentService.VerifyPaymentAsync(userId);
            return Ok(result);
        }

        
    }
}
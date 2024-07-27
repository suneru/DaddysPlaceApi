using DaddysPlaceApi.Services;
using DaddysPlaceApi.ViewEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
       
            private readonly IPaymentService _paymentService;
            public ILogger<PaymentController> _Logger { get; }

            public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
            {
                this._paymentService = paymentService;
                _Logger = logger;
            }

            [HttpGet("ListAdvance")]
            public async Task<IActionResult> ListAdvance()
            {
                var payments = await _paymentService.GetPayments();
                return Ok(payments);
            }

            [HttpGet("FetchbyId/{id}")]
            public async Task<IActionResult> FetchbyId(int id)
            {
                var payment = await _paymentService.GetPayment(id);
                if (payment == null)
                {
                    return NotFound();
                }
                return Ok(payment);
            }

            [HttpPost("Add")]
            public async Task<IActionResult> Add([FromBody] PaymentViewEntity paymentViewEntity)
            {
                _Logger.LogInformation($"Enter Request");
                var createResponce = await _paymentService.CreatePayment(paymentViewEntity);
                return StatusCode((int)HttpStatusCode.Created);
            }

            [HttpPut("Edit/{id}")]
            public async Task<IActionResult> Edit(int id, [FromBody] PaymentViewEntity paymentViewEntity)
            {
                var paymentExist = await _paymentService.GetPayment(id);
                if (paymentExist == null)
                    return NotFound();
                await _paymentService.UpdatePayment(id, paymentViewEntity);
                return NoContent();
            }

            [HttpDelete("Delete/{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var paymentExist = await _paymentService.GetPayment(id);
                if (paymentExist == null)
                    return NotFound();
                await _paymentService.DeletePayment(id);
                return NoContent();
            }
       
    }
}

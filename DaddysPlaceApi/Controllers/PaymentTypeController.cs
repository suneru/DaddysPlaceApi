using DaddysPlaceApi.Services;
using DaddysPlaceApi.ViewEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;
        public ILogger<PaymentTypeController> _Logger { get; }

        public PaymentTypeController(IPaymentTypeService paymentTypeService, ILogger<PaymentTypeController> logger)
        {
            this._paymentTypeService = paymentTypeService;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListAdvance()
        {
            var items = await _paymentTypeService.GetPaymentTypes();
            return Ok(items);
        }

        [HttpGet("FetchbyId/{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var categores = await _paymentTypeService.GetPaymentType(id);
            if (categores == null)
            {
                return NotFound();
            }
            return Ok(categores);
        }


    }
}

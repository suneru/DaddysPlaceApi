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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public ILogger<OrderController> _Logger { get; }

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            this._orderService = orderService;
            _Logger = logger;
        }

        [HttpGet("ListAdvance")]
        public async Task<IActionResult> ListAdvance()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("FetchbyId/{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var order = await _orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] OrderViewEntity orderViewEntity)
        {
            _Logger.LogInformation($"Enter Request");
            var createResponce = await _orderService.CreateOrder(orderViewEntity);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] OrderViewEntity orderViewEntity)
        {
            var orderExist = await _orderService.GetOrder(id);
            if (orderExist == null)
                return NotFound();
            await _orderService.UpdateOrder(id, orderViewEntity);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var orderExist = await _orderService.GetOrder(id);
            if (orderExist == null)
                return NotFound();
            await _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}

using DaddysPlaceApi.Services;
using DaddysPlaceApi.ViewEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ILogger<ItemController> _Logger { get; }

        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            this._itemService = itemService;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListAdvance()
        {
            var items = await _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var user = await _itemService.GetItem(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ItemViewEntity itemViewEntity)
        {
            _Logger.LogInformation($"Enter Request");
            var createResponce = await _itemService.CreateItem(itemViewEntity);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ItemViewEntity itemViewEntity)
        {
            var userExist = await _itemService.GetItem(id);
            if (userExist == null)
                return NotFound();
            await _itemService.UpdateItem(id, itemViewEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userExist = await _itemService.GetItem(id);
            if (userExist == null)
                return NotFound();
            await _itemService.DeleteItem(id);
            return NoContent();
        }
    }
}

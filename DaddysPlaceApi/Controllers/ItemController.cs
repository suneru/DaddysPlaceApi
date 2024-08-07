﻿using DaddysPlaceApi.Services;
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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ILogger<ItemController> _Logger { get; }

        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            this._itemService = itemService;
            _Logger = logger;
        }

        [HttpGet("ListAdvance")]
        public async Task<IActionResult> ListAdvance()
        {
            var items = await _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("FetchbyId/{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var user = await _itemService.GetItem(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ItemViewEntity[] itemViewEntity)
        {
            _Logger.LogInformation($"Enter Request");
            var createResponce = await _itemService.CreateItem(itemViewEntity);
            return Ok(createResponce);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ItemViewEntity itemViewEntity)
        {
            var userExist = await _itemService.GetItem(id);
            if (userExist == null)
                return NotFound();
            await _itemService.UpdateItem(id, itemViewEntity);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
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

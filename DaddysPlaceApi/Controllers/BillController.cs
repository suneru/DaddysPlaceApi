﻿using DaddysPlaceApi.Services;
using DaddysPlaceApi.ViewEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public ILogger<BillController> _Logger { get; }

        public BillController(IBillService billService, ILogger<BillController> logger)
        {
            this._billService = billService;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListAdvance()
        {
            var bills = await _billService.GetBills();
            return Ok(bills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var user = await _billService.GetBill(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BillViewEntity billViewEntity)
        {
            _Logger.LogInformation($"Enter Request");
            var createResponce = await _billService.CreateBill(billViewEntity);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] BillViewEntity billViewEntity)
        {
            var userExist = await _billService.GetBill(id);
            if (userExist == null)
                return NotFound();
            await _billService.UpdateBill(id, billViewEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userExist = await _billService.GetBill(id);
            if (userExist == null)
                return NotFound();
            await _billService.DeleteBill(id);
            return NoContent();
        }
    }
}
﻿using DaddysPlaceApi.Services;
using DaddysPlaceApi.ViewEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaddysPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public ILogger<UserController> _Logger { get; }

        public UserController(IUserService userService,ILogger<UserController> logger)
        {
            this._userService = userService;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListAdvance()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserViewEntity userViewEntity) 
        {
            _Logger.LogInformation($"Enter Request");
            var createResponce= await _userService.CreateUser(userViewEntity);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id,[FromBody] UserViewEntity userViewEntity)
        {
            var userExist = await _userService.GetUser(id);
            if (userExist == null)
            return NotFound();
            await _userService.UpdateUser(id, userViewEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userExist = await _userService.GetUser(id);
            if (userExist == null)
                return NotFound();
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}

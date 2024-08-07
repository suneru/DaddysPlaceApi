﻿using DaddysPlaceApi.Entity;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public ILogger<UserController> _Logger { get; }


        public UserController(IUserService userService,ILogger<UserController> logger)
        {
            this._userService = userService;
            _Logger = logger;
        }

        [HttpGet("ListAdvance")]
        public async Task<IActionResult> ListAdvance()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("FetchbyId/{id}")]
        public async Task<IActionResult> FetchbyId(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("FetchbyUserName")]
        public async Task<IActionResult> FetchbyUserName( string email,string password)
        {
            var user = await _userService.GetUserName(email, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UserViewEntity userViewEntity) 
        {
            _Logger.LogInformation($"Enter Request");
            UserViewEntity userExist =new UserViewEntity();

            userExist = await _userService.GetUserexist(userViewEntity.Email);
            if (userExist == null)
            {
                var createResponce = await _userService.CreateUser(userViewEntity);
                return StatusCode((int)HttpStatusCode.Created);
            }
            else {
                return StatusCode((int)HttpStatusCode.Found);
            }
            
           

        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id,[FromBody] UserVEditEntity userVEditEntity)
        {
            var userExist = await _userService.GetUser(id);
            if (userExist == null)
            return NotFound();
            await _userService.UpdateUser(id, userVEditEntity);
            return Ok("Success");
        }

        [HttpPut("EditRole/{id}")]

        public async Task<IActionResult> EditRole(int id, [FromBody] UserEditVRoleEntity userEditVRoleEntity)
        {
            var userExist = await _userService.GetUser(id);
            if (userExist == null)
                return NotFound();
            await _userService.UpdateUserRole(id, userEditVRoleEntity);
            return Ok("Success");
        }

        [HttpDelete("Delete/{id}")]
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

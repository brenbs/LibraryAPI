using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Users;
using LibraryAPI.FiltersDb;
using LibraryAPI.Models;
using LibraryAPI.Services;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _repo;
        private readonly IUserService _userService;

        public UserController(IUserRepository repo, IUserService userService)
        {
            _repo= repo; 
            _userService = userService;
        }


        [HttpPost] 
        public async Task<ActionResult> Post([FromBody] CreateUserDto createUserDto)
        {
            var result = await _userService.CreateAsync(createUserDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _userService.GetAsync();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult>GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromBody] UserDto UserDto)
        {
            var result = await _userService.UpdateAsync(UserDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] FilterDb request)
        {
            var result = await _userService.GetPagedAsync(request);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet]
        [Route("Dash")]
        public async Task<ActionResult> GetRented()
        {
            var result = await _userService.Dash();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet]
        [Route("select")]
        public async Task<ActionResult> SelectUser()
        {
            var result = await _userService.SelectUser();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
    }
}
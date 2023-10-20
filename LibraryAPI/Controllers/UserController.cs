using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Users;
using LibraryAPI.Models;
using LibraryAPI.Services;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserRepository repo, IMapper mapper, IUserService userService)
        {
            _repo= repo;
            _mapper = mapper; 
            _userService = userService;
        }


        [HttpPost] 
        public async Task<ActionResult> Post([FromBody] CreateUserDto createUserDto)
        {
            var result = await _userService.CreateAsync(createUserDto);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }        

        
    }
}
using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Users;
using LibraryAPI.Models;
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

        public UserController(IUserRepository repo,IMapper mapper)
        {
            _repo= repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _repo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetUsersById(id);
            if (user == null) return BadRequest("O Usuário não foi encontrado!");

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPost] 
        public IActionResult Post(CreateUserDto model)
        {
            var user = _mapper.Map<User>(model);
            _repo.Add(user);
            if (_repo.SaveChanges())
            {
                return Ok(user);
            }
            return BadRequest("Usuário não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserDto model)
        {
            var user = _repo.GetUsersById(id);
            if (user == null) return BadRequest("Usuário não encontrado");

            _mapper.Map(model, user);

            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));
            }
            return BadRequest("Usuário não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetUsersById(id);
            if (user == null) return BadRequest("Usuário não encontrado");

            _repo.Delete(user);
            if (_repo.SaveChanges())
            {
                return Ok("Usuário deletado");
            }
            return BadRequest("Usuário não cadastrado");
            //por dps o NotFound
        }
    }
}
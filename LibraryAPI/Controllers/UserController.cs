using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
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

        public UserController(IUserRepository repo)
        {
            _repo= repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllUsers();

            return Ok(result);
        }

        [HttpPost] 
        public IActionResult Post(User user)
        {
            _repo.Add(user);
            if(_repo.SaveChanges())
            {
                return Ok(user);
            }
            return BadRequest("Usuário não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            var use = _repo.GetUsersById(id);
            if (use == null) return BadRequest("Usuário não encontrado");

            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Ok(user);
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
                return Ok("Aluno deletado");
            }
            return BadRequest("Usuário não cadastrado");
        }
    }
}

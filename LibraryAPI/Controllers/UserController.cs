using LibraryAPI.Data;
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
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Users);
        }

        [HttpGet("ById/{id}")] //{} parâmetro é tipo como se ficasse LibraryAPI/Users/(id)
        public IActionResult GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return BadRequest("O Usuário não foi encontrado");

            return Ok(user);
        }

        [HttpGet("ByName")] //aqui ele filtra só por nome
        public IActionResult GetByName(string name)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name.Contains(name));
            if (user == null) return BadRequest("O Usuário não foi encontrado");

            return Ok(user);
        }

        [HttpPost] 
        public IActionResult Post(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            var use = _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (use == null) return BadRequest("Usuário não encontrado");
            _context.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (user == null) return BadRequest("Usuário não encontrado");
            _context.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}

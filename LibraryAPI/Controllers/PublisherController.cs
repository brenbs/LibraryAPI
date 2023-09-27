using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController  : ControllerBase
    {
        private readonly DataContext _context;

        public PublisherController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Publishers);
        }

        [HttpGet("ById/{id}")] //{} parâmetro é tipo como se ficasse LibraryAPI/Publishers/(id)
        public IActionResult GetById(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (publisher == null) return BadRequest("A Editora não foi encontrada");

            return Ok(publisher);
        }

        [HttpGet("ByName")] //aqui ele filtra só por nome
        public IActionResult GetByName(string name)
        {
            var publisher = _context.Publishers.FirstOrDefault(p => p.Name.Contains(name));
            if (publisher == null) return BadRequest("A  Editora não foi encontrada");

            return Ok(publisher);
        }

        [HttpPost] 
        public IActionResult Post(Publisher publisher)
        {
            _context.Add(publisher);
            _context.SaveChanges();
            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Publisher publisher)
        {
            var pub = _context.Publishers.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (pub == null) return BadRequest("Usuário não encontrado");
            _context.Update(publisher);
            _context.SaveChanges();
            return Ok(publisher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _context.Publishers.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (publisher == null) return BadRequest("Usuário não encontrado");
            _context.Remove(publisher);
            _context.SaveChanges();
            return Ok();
        }
    }
}

using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public List<User> Users = new List<User>()  //List <do tipo user> 
        {
          new User()
          {
              Id=1,
              Name="Brenda",
              Email="brenbs@gmail.com",
              Telephone=85958394,
              Adress="Álvaro Weyne rua Manoel Pereira n°489",
              City="Fortaleza,CE"
          },
          new User()
          {
              Id=2,
              Name="Emauela",
              Email="manhu@gmail.com",
              Telephone=25656532,
              Adress="Moranguinho, rua Maria n°321",
              City="Horizonte,CE"
          },
          new User()
          {
              Id=3,
              Name="Heloísa",
              Email="lolo@gmail.com",
              Telephone=85503593,
              Adress="Damas, rua Professor Costa Mendes n°933",
              City="Fortaleza,CE"
          },
        };
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }

        [HttpGet("ById/{id}")] //{} parâmetro é tipo como se ficasse LibraryAPI/Users/(id)
        public IActionResult GetById(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return BadRequest("O Usuário não foi encontrado");

            return Ok(user);
        }

        [HttpGet("ByName")] //aqui ele filtra sópor nome
        public IActionResult GetByName(string name)
        {
            var user = Users.FirstOrDefault(u => u.Name.Contains(name));
            if (user == null) return BadRequest("O Usuário não foi encontrado");

            return Ok(user);
        }

        [HttpPost] 
        public IActionResult Post(User user)
        {
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, User user)
        {
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

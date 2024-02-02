using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        [HttpGet]
        public IActionResult List() {
            return Ok(_service.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id) {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] User newUser) {
            var user = _service.Create(newUser);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] User userUpdate, [FromRoute] int id) {
            return Ok(_service.Update(userUpdate,id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) {
            _service.Delete(id);
            return NoContent();
        }
    }
}

using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult List() {
            return Ok(_service.List());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product newProduct)
        {
            return Ok(_service.Create(newProduct));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Product productUpdateData, int id)
        {
            return Ok(_service.Update(productUpdateData, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) {
            _service.Delete(id);
            return NoContent();
        }

    }
}

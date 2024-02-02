using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_orderService.List());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_orderService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order newOrder) {
            return Ok(_orderService.Create(newOrder));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Order orderUpdateData, int id) { 
            return Ok(_orderService.Update(orderUpdateData, id));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            _orderService.Delete(id);
            return NoContent();
        }
    }
}

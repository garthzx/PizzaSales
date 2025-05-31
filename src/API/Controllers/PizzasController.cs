using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase {
        private readonly IPizzaService _pizzaService;

        public PizzasController(IPizzaService pizzaService) {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAll() {
            return Ok(await _pizzaService.GetAllPizzasAsync());
        }
    }
}

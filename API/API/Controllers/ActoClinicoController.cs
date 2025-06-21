using DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActoClinicoController : ControllerBase
    {
        private readonly IActoClinicoService _service;

        public ActoClinicoController(IActoClinicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.ObterTodosAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.ObterPorIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActoClinicoDTO dto)
        {
            var success = await _service.CriarAsync(dto);
            if (!success) return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActoClinicoDTO dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch.");
            var success = await _service.AtualizarAsync(dto);
            if (!success) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.RemoverAsync(id);
            if (!success) return NotFound();
            return Ok();
        }
    }
}

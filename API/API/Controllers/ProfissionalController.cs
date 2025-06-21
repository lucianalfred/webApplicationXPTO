using DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalService _service;

        public ProfissionalController(IProfissionalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProfissionalDTO>>> ObterTodos()
        {
            var lista = await _service.ObterTodosAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfissionalDTO>> ObterPorId(int id)
        {
            var profissional = await _service.ObterPorIdAsync(id);
            if (profissional == null) return NotFound();
            return Ok(profissional);
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] ProfissionalDTO dto)
        {
            var sucesso = await _service.CriarAsync(dto);
            if (!sucesso) return BadRequest("Erro ao criar profissional.");
            return Ok("Profissional criado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] ProfissionalDTO dto)
        {
            if (id != dto.Id) return BadRequest("IDs não correspondem.");
            var sucesso = await _service.AtualizarAsync(dto);
            if (!sucesso) return NotFound("Profissional não encontrado.");
            return Ok("Profissional atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            var sucesso = await _service.RemoverAsync(id);
            if (!sucesso) return NotFound("Profissional não encontrado.");
            return Ok("Profissional removido com sucesso.");
        }
    }
}

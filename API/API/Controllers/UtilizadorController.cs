using DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        private readonly IUtilizadorService _service;

        public UtilizadorController(IUtilizadorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var utilizadores = await _service.ObterTodosAsync();
            return Ok(utilizadores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var utilizador = await _service.ObterPorIdAsync(id);
            if (utilizador == null)
                return NotFound();

            return Ok(utilizador);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] UtilizadorDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool criado = await _service.CriarAsync(dto);
            if (!criado)
                return StatusCode(500, "Erro ao criar utilizador.");

            return Ok(new { message = "Utilizador criado com sucesso." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UtilizadorDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID inconsistente.");

            bool atualizado = await _service.AtualizarAsync(dto);
            if (!atualizado)
                return NotFound("Utilizador não encontrado.");

            return Ok(new { message = "Utilizador atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            bool removido = await _service.RemoverAsync(id);
            if (!removido)
                return NotFound("Utilizador não encontrado.");

            return Ok(new { message = "Utilizador removido com sucesso." });
        }
    }
}

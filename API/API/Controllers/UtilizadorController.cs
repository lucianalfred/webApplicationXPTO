using DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        private readonly IUtilizadorService _service;
        public UtilizadorController(IUtilizadorService service) => _service = service;

        // GET api/Utilizador
        [HttpGet]
        [Authorize(Roles = "Administrador")]          
        public async Task<IActionResult> ObterTodos()
            => Ok(await _service.ObterTodosAsync());

        // GET api/Utilizador/42
        [HttpGet("{id:int}")]
        [Authorize]                                   
        public async Task<IActionResult> ObterPorId(int id)
        {
            var u = await _service.ObterPorIdAsync(id);
            return u is null ? NotFound() : Ok(u);
        }

        // POST api/Utilizador
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Criar([FromBody] UtilizadorDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ok = await _service.CriarAsync(dto);
            return ok
                ? Ok(new { message = "Utilizador criado com sucesso." })
                : StatusCode(500, "Erro ao criar utilizador.");
        }

        // PUT api/Utilizador/42
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UtilizadorDTO dto)
        {
            dto.Id = id;                              
            var ok = await _service.AtualizarAsync(dto);
            return ok
                ? Ok(new { message = "Utilizador atualizado com sucesso." })
                : NotFound("Utilizador não encontrado.");
        }

        // DELETE api/Utilizador/42
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Remover(int id)
        {
            var ok = await _service.RemoverAsync(id);
            return ok
                ? Ok(new { message = "Utilizador removido com sucesso." })
                : NotFound("Utilizador não encontrado.");
        }
    }
}

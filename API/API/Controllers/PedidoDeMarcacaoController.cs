using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoDeMarcacaoController : ControllerBase
    {
        private readonly IPedidoDeMarcacaoService _pedidoService;

        public PedidoDeMarcacaoController(IPedidoDeMarcacaoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDeMarcacaoDTO>>> ObterTodos()
        {
            var pedidos = await _pedidoService.ObterTodosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDeMarcacaoDTO>> ObterPorId(int id)
        {
            var pedido = await _pedidoService.ObterPorIdAsync(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDeMarcacaoDTO>> Criar([FromBody] PedidoDeMarcacaoDTO dto)
        {
            var novoPedido = await _pedidoService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = novoPedido.Id }, novoPedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] PedidoDeMarcacaoDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID do pedido não coincide com o corpo da requisição.");

            var atualizado = await _pedidoService.AtualizarAsync(dto);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var removido = await _pedidoService.RemoverAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}

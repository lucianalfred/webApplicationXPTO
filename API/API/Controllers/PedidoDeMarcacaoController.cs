using DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
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

        // GET: api/PedidoDeMarcacao
        
        [HttpGet]
        [Authorize(Roles = "Utente,Administrativo,Administrador")]
    
        public IActionResult GetAll()
        {
            var pedidos = _pedidoService.GetAll();
            return Ok(pedidos);
        }

        // GET: api/PedidoDeMarcacao/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Utente,Administrativo,Administrador")]
        public IActionResult GetById(int id)
        {
            var pedido = _pedidoService.GetById(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        // POST: api/PedidoDeMarcacao
        [HttpPost]
        [Authorize(Roles = "Administrativo,Administrador")]
        public IActionResult Create([FromBody] PedidoDeMarcacaoDTO pedidoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = _pedidoService.Save(pedidoDto);
            if (!result)
                return StatusCode(500, "Erro ao criar o pedido de marcação.");

            return Ok(new { message = "Pedido de marcação criado com sucesso!" });
        }

        // PUT: api/PedidoDeMarcacao/5
        [Authorize(Roles = "Administrativo,Administrador")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PedidoDeMarcacaoDTO pedidoDto)
        {
            if (id != pedidoDto.Id)
                return BadRequest("ID do corpo e da URL não coincidem.");

            bool result = _pedidoService.Update(pedidoDto);
            if (!result)
                return NotFound("Pedido de marcação não encontrado para atualização.");

            return Ok(new { message = "Pedido de marcação atualizado com sucesso!" });
        }

        // DELETE: api/PedidoDeMarcacao/5
        [HttpDelete]
        [Authorize(Roles = "Administrativo,Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _pedidoService.Delete(id);
            if (!result)
                return NotFound("Pedido de marcação não encontrado para exclusão.");

            return Ok(new { message = "Pedido de marcação removido com sucesso!" });
        }
    }
}

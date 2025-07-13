using DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        [HttpPost("anonimo")]
        [AllowAnonymous]
        public async Task<IActionResult> CriarPedidoAnonimo([FromBody] PedidoDeMarcacaoAnonimoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var sucesso = await _pedidoService.SaveAnonimo(dto);

                if (!sucesso)
                    return StatusCode(500, "Erro ao processar pedido anónimo.");

                return Ok(new { message = "Pedido de marcação anónimo enviado com sucesso!" });
        }
         catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
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
        [Authorize(Roles = "Utente,Administrativo,Administrador")]
        
        public async Task<IActionResult> Create(PedidoDeMarcacaoDTO pedidoDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return BadRequest("Utilizador não autenticado");

            pedidoDto.IdUsuario = int.Parse(userIdClaim);
            
            Console.WriteLine($"UtenteRegistadoId   : {pedidoDto.UtenteRegistadoId}");
            Console.WriteLine($"AdminstractivoId    : {pedidoDto.AdminstractivoId}");
            Console.WriteLine($"IdUsuario (Utilizador): {pedidoDto.IdUsuario}");

            var result = await _pedidoService.Save(pedidoDto);

            if (result)
                return Ok(new { message = "Pedido registado com sucesso." });

            return BadRequest("Erro ao registar o pedido.");
        }
        // api/PedidoDeMarcacao/usuario/42
        [HttpGet("usuario/{idUsuario:int}")]
        [Authorize(Roles = "Utente,Administrativo,Administrador")]
        public IActionResult HistoricoPorUsuario(int idUsuario)
        {
            var lista = _pedidoService.GetByUsuario(idUsuario);
            return Ok(lista);
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

       //// PUT: api/PedidoDeMarcacao/42/agendar
    [Authorize(Roles = "Administrativo,Administrador")]
    [HttpPut("{id:int}/agendar")]
    public async Task<IActionResult> AgendarPedido(int id, [FromBody] AgendarPedidoDTO dto)
    {
        var ok = await _pedidoService.AgendarAsync(id,
                     dto.DataDeAgendamentoDoPedidoDeMarcacao  ?? DateTime.UtcNow);

        return ok ? Ok(new { message = "Pedido agendado com sucesso." }): NotFound("Pedido não encontrado.");
    }      

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

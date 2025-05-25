using Microsoft.AspNetCore.Mvc;
using DTO;
using Interfaces;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtenteRegistadoController : ControllerBase
    {
        private static List<UtenteRegistado> _utentes = new();

        // GET: api/UtenteRegistado
        [HttpGet]
        public ActionResult<IEnumerable<UtenteRegistado>> GetAll()
        {
            return Ok(_utentes);
        }

        // GET: api/UtenteRegistado/5
        [HttpGet("{id}")]
        public ActionResult<UtenteRegistado> GetById(int id)
        {
            var utente = _utentes.FirstOrDefault(u => u.NumeroUtente == id);
            if (utente == null)
                return NotFound();

            return Ok(utente);
        }

        // POST: api/UtenteRegistado
        [HttpPost]
        public ActionResult<UtenteRegistado> Create([FromBody] UtenteRegistado utente)
        {
            _utentes.Add(utente);
            return CreatedAtAction(nameof(GetById), new { id = utente.NumeroUtente}, utente);
        }

        // PUT: api/UtenteRegistado/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UtenteRegistado utenteAtualizado)
        {
            var index = _utentes.FindIndex(u => u.NumeroUtente == id);
            if (index == -1)
                return NotFound();

            _utentes[index] = utenteAtualizado;
            return NoContent();
        }

        // DELETE: api/UtenteRegistado/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var utente = _utentes.FirstOrDefault(u => u.NumeroUtente == id);
            if (utente == null)
                return NotFound();

            _utentes.Remove(utente);
            return NoContent();
        }
    }
}
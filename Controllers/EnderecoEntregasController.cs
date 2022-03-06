#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlurayDreamsAPI.Context;
using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoEntregasController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public EnderecoEntregasController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/EnderecoEntregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoEntrega>>> GetEnderecoEntregas()
        {
            return await _context.EnderecoEntregas.ToListAsync();
        }

        // GET: api/EnderecoEntregas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoEntrega>> GetEnderecoEntrega(int id)
        {
            var enderecoEntrega = await _context.EnderecoEntregas.FindAsync(id);

            if (enderecoEntrega == null)
            {
                return NotFound();
            }

            return enderecoEntrega;
        }

        // PUT: api/EnderecoEntregas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoEntrega(int id, EnderecoEntrega enderecoEntrega)
        {
            if (id != enderecoEntrega.Id)
            {
                return BadRequest();
            }

            _context.Entry(enderecoEntrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoEntregaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EnderecoEntregas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnderecoEntrega>> PostEnderecoEntrega(EnderecoEntrega enderecoEntrega)
        {
            _context.EnderecoEntregas.Add(enderecoEntrega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoEntrega", new { id = enderecoEntrega.Id }, enderecoEntrega);
        }

        // DELETE: api/EnderecoEntregas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoEntrega(int id)
        {
            var enderecoEntrega = await _context.EnderecoEntregas.FindAsync(id);
            if (enderecoEntrega == null)
            {
                return NotFound();
            }

            _context.EnderecoEntregas.Remove(enderecoEntrega);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [Route("{clienteId}/cliente")]
        [HttpGet]
        public IActionResult GetEnderecoEntregaporCliente(int clienteId)
        {
            var enderecoEntrega = _context.EnderecoEntregas.Where(x => x.ClienteId == clienteId).ToList();

            return Ok(enderecoEntrega);
        }

        private bool EnderecoEntregaExists(int id)
        {
            return _context.EnderecoEntregas.Any(e => e.Id == id);
        }
    }
}

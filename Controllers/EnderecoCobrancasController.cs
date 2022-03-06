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
    public class EnderecoCobrancasController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public EnderecoCobrancasController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/EnderecoCobrancas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoCobranca>>> GetEnderecoCobrancas()
        {
            return await _context.EnderecoCobrancas.ToListAsync();
        }

        // GET: api/EnderecoCobrancas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoCobranca>> GetEnderecoCobranca(int id)
        {
            var enderecoCobranca = await _context.EnderecoCobrancas.FindAsync(id);

            if (enderecoCobranca == null)
            {
                return NotFound();
            }

            return enderecoCobranca;
        }

        // PUT: api/EnderecoCobrancas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoCobranca(int id, EnderecoCobranca enderecoCobranca)
        {
            if (id != enderecoCobranca.Id)
            {
                return BadRequest();
            }

            _context.Entry(enderecoCobranca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoCobrancaExists(id))
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

        // POST: api/EnderecoCobrancas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnderecoCobranca>> PostEnderecoCobranca(EnderecoCobranca enderecoCobranca)
        {
            _context.EnderecoCobrancas.Add(enderecoCobranca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoCobranca", new { id = enderecoCobranca.Id }, enderecoCobranca);
        }

        // DELETE: api/EnderecoCobrancas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoCobranca(int id)
        {
            var enderecoCobranca = await _context.EnderecoCobrancas.FindAsync(id);
            if (enderecoCobranca == null)
            {
                return NotFound();
            }

            _context.EnderecoCobrancas.Remove(enderecoCobranca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("{clienteId}/cliente")]
        [HttpGet]
        public IActionResult GetEnderecoCobrancaporCliente(int clienteId)
        {
            var enderecoCobranca = _context.EnderecoCobrancas.Where(x => x.ClienteId == clienteId).ToList();
            
            return Ok(enderecoCobranca);
        }

        private bool EnderecoCobrancaExists(int id)
        {
            return _context.EnderecoCobrancas.Any(e => e.Id == id);
        }
    }
}

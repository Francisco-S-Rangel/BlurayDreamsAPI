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
using BlurayDreamsAPI.BusinessModels;

namespace BlurayDreamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivacaoClientesController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public AtivacaoClientesController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/AtivacaoClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtivacaoCliente>>> GetAtivacaoClientes()
        {
            return await _context.AtivacaoClientes.ToListAsync();
        }

        // GET: api/AtivacaoClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtivacaoCliente>> GetAtivacaoCliente(int id)
        {
            var ativacaoCliente = await _context.AtivacaoClientes.FindAsync(id);

            if (ativacaoCliente == null)
            {
                return NotFound();
            }

            return ativacaoCliente;
        }

        // PUT: api/AtivacaoClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtivacaoCliente(int id, AtivacaoClienteModel ativacaoCliente)
        {
            if (id != ativacaoCliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(ativacaoCliente.toEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtivacaoClienteExists(id))
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

        // POST: api/AtivacaoClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AtivacaoCliente>> PostAtivacaoCliente(AtivacaoClienteModel ativacaoCliente)
        {
            _context.AtivacaoClientes.Add(ativacaoCliente.toEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtivacaoCliente", new { id = ativacaoCliente.Id }, ativacaoCliente);
        }

        // DELETE: api/AtivacaoClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtivacaoCliente(int id)
        {
            var ativacaoCliente = await _context.AtivacaoClientes.FindAsync(id);
            if (ativacaoCliente == null)
            {
                return NotFound();
            }

            _context.AtivacaoClientes.Remove(ativacaoCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtivacaoClienteExists(int id)
        {
            return _context.AtivacaoClientes.Any(e => e.Id == id);
        }
    }
}

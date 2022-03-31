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
    public class DesativacaoClientesController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public DesativacaoClientesController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/DesativacaoClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesativacaoCliente>>> GetDesativacaoClientes()
        {
            return await _context.DesativacaoClientes.ToListAsync();
        }

        // GET: api/DesativacaoClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesativacaoCliente>> GetDesativacaoCliente(int id)
        {
            var desativacaoCliente = await _context.DesativacaoClientes.FindAsync(id);

            if (desativacaoCliente == null)
            {
                return NotFound();
            }

            return desativacaoCliente;
        }

        // PUT: api/DesativacaoClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesativacaoCliente(int id, DesativacaoCliente desativacaoCliente)
        {
            if (id != desativacaoCliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(desativacaoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesativacaoClienteExists(id))
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

        // POST: api/DesativacaoClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DesativacaoCliente>> PostDesativacaoCliente(DesativacaoCliente desativacaoCliente)
        {
            _context.DesativacaoClientes.Add(desativacaoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesativacaoCliente", new { id = desativacaoCliente.Id }, desativacaoCliente);
        }

        // DELETE: api/DesativacaoClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesativacaoCliente(int id)
        {
            var desativacaoCliente = await _context.DesativacaoClientes.FindAsync(id);
            if (desativacaoCliente == null)
            {
                return NotFound();
            }

            _context.DesativacaoClientes.Remove(desativacaoCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesativacaoClienteExists(int id)
        {
            return _context.DesativacaoClientes.Any(e => e.Id == id);
        }
    }
}

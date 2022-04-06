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
    public class TrocasController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public TrocasController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/Trocas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Troca>>> GetTrocas()
        {
            return await _context.Trocas.ToListAsync();
        }

        // GET: api/Trocas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Troca>> GetTroca(int id)
        {
            var troca = await _context.Trocas.FindAsync(id);

            if (troca == null)
            {
                return NotFound();
            }

            return troca;
        }

        // PUT: api/Trocas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTroca(int id, TrocaModel troca)
        {
            if (id != troca.Id)
            {
                return BadRequest();
            }

            _context.Entry(troca.toEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrocaExists(id))
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

        // POST: api/Trocas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Troca>> PostTroca(TrocaModel troca)
        {
            _context.Trocas.Add(troca.toEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTroca", new { id = troca.Id }, troca);
        }

        // DELETE: api/Trocas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTroca(int id)
        {
            var troca = await _context.Trocas.FindAsync(id);
            if (troca == null)
            {
                return NotFound();
            }

            _context.Trocas.Remove(troca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrocaExists(int id)
        {
            return _context.Trocas.Any(e => e.Id == id);
        }
    }
}

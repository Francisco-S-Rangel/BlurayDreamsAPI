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
    public class AtivacaoFuncionariosController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public AtivacaoFuncionariosController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/AtivacaoFuncionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtivacaoFuncionario>>> GetAtivacaoFuncionarios()
        {
            return await _context.AtivacaoFuncionarios.ToListAsync();
        }

        // GET: api/AtivacaoFuncionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtivacaoFuncionario>> GetAtivacaoFuncionario(int id)
        {
            var ativacaoFuncionario = await _context.AtivacaoFuncionarios.FindAsync(id);

            if (ativacaoFuncionario == null)
            {
                return NotFound();
            }

            return ativacaoFuncionario;
        }

        // PUT: api/AtivacaoFuncionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtivacaoFuncionario(int id, AtivacaoFuncionario ativacaoFuncionario)
        {
            if (id != ativacaoFuncionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(ativacaoFuncionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtivacaoFuncionarioExists(id))
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

        // POST: api/AtivacaoFuncionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AtivacaoFuncionario>> PostAtivacaoFuncionario(AtivacaoFuncionario ativacaoFuncionario)
        {
            _context.AtivacaoFuncionarios.Add(ativacaoFuncionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtivacaoFuncionario", new { id = ativacaoFuncionario.Id }, ativacaoFuncionario);
        }

        // DELETE: api/AtivacaoFuncionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtivacaoFuncionario(int id)
        {
            var ativacaoFuncionario = await _context.AtivacaoFuncionarios.FindAsync(id);
            if (ativacaoFuncionario == null)
            {
                return NotFound();
            }

            _context.AtivacaoFuncionarios.Remove(ativacaoFuncionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtivacaoFuncionarioExists(int id)
        {
            return _context.AtivacaoFuncionarios.Any(e => e.Id == id);
        }
    }
}

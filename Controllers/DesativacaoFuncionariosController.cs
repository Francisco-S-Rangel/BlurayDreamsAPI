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
    public class DesativacaoFuncionariosController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public DesativacaoFuncionariosController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/DesativacaoFuncionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesativacaoFuncionario>>> GetDesativacaoFuncionarios()
        {
            return await _context.DesativacaoFuncionarios.ToListAsync();
        }

        // GET: api/DesativacaoFuncionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesativacaoFuncionario>> GetDesativacaoFuncionario(int id)
        {
            var desativacaoFuncionario = await _context.DesativacaoFuncionarios.FindAsync(id);

            if (desativacaoFuncionario == null)
            {
                return NotFound();
            }

            return desativacaoFuncionario;
        }

        // PUT: api/DesativacaoFuncionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesativacaoFuncionario(int id, DesativacaoFuncionarioModel desativacaoFuncionario)
        {
            if (id != desativacaoFuncionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(desativacaoFuncionario.toEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesativacaoFuncionarioExists(id))
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

        // POST: api/DesativacaoFuncionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DesativacaoFuncionario>> PostDesativacaoFuncionario(DesativacaoFuncionarioModel desativacaoFuncionario)
        {
            _context.DesativacaoFuncionarios.Add(desativacaoFuncionario.toEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesativacaoFuncionario", new { id = desativacaoFuncionario.Id }, desativacaoFuncionario);
        }

        // DELETE: api/DesativacaoFuncionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesativacaoFuncionario(int id)
        {
            var desativacaoFuncionario = await _context.DesativacaoFuncionarios.FindAsync(id);
            if (desativacaoFuncionario == null)
            {
                return NotFound();
            }

            _context.DesativacaoFuncionarios.Remove(desativacaoFuncionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesativacaoFuncionarioExists(int id)
        {
            return _context.DesativacaoFuncionarios.Any(e => e.Id == id);
        }
    }
}

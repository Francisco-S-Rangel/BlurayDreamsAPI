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
    public class AtivacaoProdutosController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public AtivacaoProdutosController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/AtivacaoProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtivacaoProduto>>> GetAtivacaoProdutos()
        {
            return await _context.AtivacaoProdutos.ToListAsync();
        }

        // GET: api/AtivacaoProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtivacaoProduto>> GetAtivacaoProduto(int id)
        {
            var ativacaoProduto = await _context.AtivacaoProdutos.FindAsync(id);

            if (ativacaoProduto == null)
            {
                return NotFound();
            }

            return ativacaoProduto;
        }

        // PUT: api/AtivacaoProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtivacaoProduto(int id, AtivacaoProdutoModel ativacaoProduto)
        {
            if (id != ativacaoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(ativacaoProduto.toEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtivacaoProdutoExists(id))
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

        // POST: api/AtivacaoProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AtivacaoProduto>> PostAtivacaoProduto(AtivacaoProdutoModel ativacaoProduto)
        {
            _context.AtivacaoProdutos.Add(ativacaoProduto.toEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtivacaoProduto", new { id = ativacaoProduto.Id }, ativacaoProduto);
        }

        // DELETE: api/AtivacaoProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtivacaoProduto(int id)
        {
            var ativacaoProduto = await _context.AtivacaoProdutos.FindAsync(id);
            if (ativacaoProduto == null)
            {
                return NotFound();
            }

            _context.AtivacaoProdutos.Remove(ativacaoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtivacaoProdutoExists(int id)
        {
            return _context.AtivacaoProdutos.Any(e => e.Id == id);
        }
    }
}

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
    public class DesativacaoProdutosController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public DesativacaoProdutosController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/DesativacaoProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesativacaoProduto>>> GetDesativacaoProdutos()
        {
            return await _context.DesativacaoProdutos.ToListAsync();
        }

        // GET: api/DesativacaoProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesativacaoProduto>> GetDesativacaoProduto(int id)
        {
            var desativacaoProduto = await _context.DesativacaoProdutos.FindAsync(id);

            if (desativacaoProduto == null)
            {
                return NotFound();
            }

            return desativacaoProduto;
        }

        // PUT: api/DesativacaoProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesativacaoProduto(int id, DesativacaoProdutoModel desativacaoProduto)
        {
            if (id != desativacaoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(desativacaoProduto.toEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesativacaoProdutoExists(id))
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

        // POST: api/DesativacaoProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DesativacaoProduto>> PostDesativacaoProduto(DesativacaoProdutoModel desativacaoProduto)
        {
            _context.DesativacaoProdutos.Add(desativacaoProduto.toEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesativacaoProduto", new { id = desativacaoProduto.Id }, desativacaoProduto);
        }

        // DELETE: api/DesativacaoProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesativacaoProduto(int id)
        {
            var desativacaoProduto = await _context.DesativacaoProdutos.FindAsync(id);
            if (desativacaoProduto == null)
            {
                return NotFound();
            }

            _context.DesativacaoProdutos.Remove(desativacaoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesativacaoProdutoExists(int id)
        {
            return _context.DesativacaoProdutos.Any(e => e.Id == id);
        }
    }
}

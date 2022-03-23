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
    public class CartaoCreditosController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public CartaoCreditosController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/CartaoCreditoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartaoCredito>>> GetCartaoCreditos()
        {
            return await _context.CartaoCreditos.ToListAsync();
        }

        // GET: api/CartaoCreditoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartaoCredito>> GetCartaoCredito(int id)
        {
            var cartaoCredito = await _context.CartaoCreditos.FindAsync(id);

            if (cartaoCredito == null)
            {
                return NotFound();
            }

            return cartaoCredito;
        }

        // PUT: api/CartaoCreditoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartaoCredito(int id, CartaoCreditoModel cartaoCredito)
        {
            if (id != cartaoCredito.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartaoCredito.toEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoCreditoExists(id))
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

        // POST: api/CartaoCreditoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartaoCredito>> PostCartaoCredito(CartaoCreditoModel cartaoCredito)
        {
            _context.CartaoCreditos.Add(cartaoCredito.toEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartaoCredito", new { id = cartaoCredito.Id }, cartaoCredito);
        }

        // DELETE: api/CartaoCreditoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartaoCredito(int id)
        {
            var cartaoCredito = await _context.CartaoCreditos.FindAsync(id);
            if (cartaoCredito == null)
            {
                return NotFound();
            }

            _context.CartaoCreditos.Remove(cartaoCredito);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [Route("{clienteId}/cliente")]
        [HttpGet]
        public IActionResult CartaoCreditosliente(int clienteId)
        {
            var cartaoCreditos = _context.CartaoCreditos.Where(x => x.ClienteId == clienteId).ToList();

            return Ok(cartaoCreditos);
        }


        private bool CartaoCreditoExists(int id)
        {
            return _context.CartaoCreditos.Any(e => e.Id == id);
        }
    }
}

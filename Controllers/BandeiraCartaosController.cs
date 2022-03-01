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
    public class BandeiraCartaosController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public BandeiraCartaosController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/BandeiraCartaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BandeiraCartao>>> GetBandeiraCartaos()
        {
            return await _context.BandeiraCartaos.ToListAsync();
        }

        // GET: api/BandeiraCartaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BandeiraCartao>> GetBandeiraCartao(int id)
        {
            var bandeiraCartao = await _context.BandeiraCartaos.FindAsync(id);

            if (bandeiraCartao == null)
            {
                return NotFound();
            }

            return bandeiraCartao;
        }

        // PUT: api/BandeiraCartaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBandeiraCartao(int id, BandeiraCartao bandeiraCartao)
        {
            if (id != bandeiraCartao.Id)
            {
                return BadRequest();
            }

            _context.Entry(bandeiraCartao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BandeiraCartaoExists(id))
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

        // POST: api/BandeiraCartaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BandeiraCartao>> PostBandeiraCartao(BandeiraCartao bandeiraCartao)
        {
            _context.BandeiraCartaos.Add(bandeiraCartao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBandeiraCartao", new { id = bandeiraCartao.Id }, bandeiraCartao);
        }

        // DELETE: api/BandeiraCartaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBandeiraCartao(int id)
        {
            var bandeiraCartao = await _context.BandeiraCartaos.FindAsync(id);
            if (bandeiraCartao == null)
            {
                return NotFound();
            }

            _context.BandeiraCartaos.Remove(bandeiraCartao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BandeiraCartaoExists(int id)
        {
            return _context.BandeiraCartaos.Any(e => e.Id == id);
        }
    }
}

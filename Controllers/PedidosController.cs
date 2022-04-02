﻿#nullable disable
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
    public class PedidosController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public PedidosController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
            return await _context.Pedido.ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidoModel pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido.toEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(PedidoModel pedido)
        {
            _context.Pedido.Add(pedido.toEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.Id == id);
        }
        
        [Route("{clienteId}/cliente")]
        [HttpGet]
        public IActionResult GetPedidoProduto(int clienteId)
        {
            var pedidos = _context.Pedido.Where(x=> x.ClienteId == clienteId)
                                        .Include(x => x.PedidoProdutos)
                                        .Select(x => new 
                                        {
                                            ClienteId = x.ClienteId,
                                            Id = x.Id,
                                            EnderecoEntregaId = x.EnderecoEntregaId,
                                            EnderecoCobrancaId = x.EnderecoCobrancaId,
                                            CartaoCreditoId = x.CartaoCreditoId,
                                            Desconto = x.Desconto,
                                            Frete = x.Frete,
                                            PrecoFinal = x.PrecoFinal,
                                            Status = x.Status,
                                            PedidoProdutos = x.PedidoProdutos
                                        })
                                        .ToArray();
            return Ok(pedidos);

        }
    }
}

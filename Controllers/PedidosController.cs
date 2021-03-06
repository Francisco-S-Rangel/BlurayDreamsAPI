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
using BlurayDreamsAPI.Utilities;

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
                                            CartaoCreditoId2 = x.CartaoCreditoId2,
                                            CartaoCreditoId3 = x.CartaoCreditoId3,
                                            DataPedido = x.DataPedido,
                                            Desconto = x.Desconto,
                                            Frete = x.Frete,
                                            PrecoFinal = x.PrecoFinal,
                                            Status = x.Status,
                                            PedidoProdutos = x.PedidoProdutos
                                        })
                                        .ToArray();
            return Ok(pedidos);

        }

        [Route("{clienteId}/troca")]
        [HttpPost]
        public IActionResult PostTroca(int clienteId,[FromBody] List<TrocaRequest> request)
        {
            var trocas = request.Select(x => new Troca
            {
                Id = 0,
                ClienteId = clienteId,
                PedidoId = x.PedidoId,
                PedidoProdutoId = x.PedidoProdutoId,
                Quantidade = x.Quantidadde,
                Status = StatusTroca.EmTroca,
                RecebimentoProduto = false,

            }).ToList();

            _context.Trocas.AddRange(trocas);
            _context.SaveChanges();

            return Ok();
        }

      [Route("dashboard-vendas")]
      [HttpGet]
      public IActionResult pegarCategoriaporData([FromQuery]DateTime dataInit, [FromQuery]DateTime dataFinal)
        {
            // Similar ao innerjoin
            // Traz a entidade Produto
            // Traz a entidade Pedido
            // Groupby por Categoria pegando a data separada por mes e ano
            var response = _context.PedidoProdutos
                    .Include(x => x.Pedido) 
                    .Include(x => x.Produto)
                    .Where(x => x.Pedido.DataPedido >= dataInit && x.Pedido.DataPedido <= dataFinal)
                    .AsEnumerable()
                    .GroupBy(x => x.Produto.Categoria)
                    .Select(x => new RespostaGrafico
                    {
                        Categoria = x.Key,
                        Valores = x.AsEnumerable().GroupBy(y => new {y.Pedido.DataPedido.Month, y.Pedido.DataPedido.Year }).Select(y => new Valor
                        {
                            Data = new DateTime(y.Key.Year, y.Key.Month, 1),
                            Quantidade = y.Sum(z => z.quantidade)
                        }).ToList()
                    }).ToList();

            var dates = new List<DateTime>();
            // retorna datas de todos os messes entre essas datas
            while (dataInit<=dataFinal)
            {
                dates.Add(new DateTime (dataInit.Year,dataInit.Month,1));
                dataInit = dataInit.AddMonths(1);
            }
            //adiciona valores nulo caso existam e transforma em 0 para o banco não entregar errado
            dates.ForEach(date =>
            {
                response.ForEach(res =>
                {
                    if (res.Valores.Find(x => x.Data == date) == null)
                    {
                        res.Valores.Add(new Valor { Data = date, Quantidade = 0 });
                    }
                });
            });
            //ordena os valores
            response.ForEach(resp =>
            { 
                resp.Valores = resp.Valores.OrderBy(x => x.Data).ToList();
            });

            return Ok(new { 
                Meses = dates,
                response = response,
            });

        }
    }
}

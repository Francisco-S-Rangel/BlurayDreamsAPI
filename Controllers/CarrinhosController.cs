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
    public class CarrinhosController : ControllerBase
    {
        private readonly BlurayDreamsContexto _context;

        public CarrinhosController(BlurayDreamsContexto context)
        {
            _context = context;
        }

        // GET: api/Carrinhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrinho>>> GetCarrinho()
        {
            return await _context.Carrinho.ToListAsync();
        }

        // GET: api/Carrinhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrinho>> GetCarrinho(int id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);

            if (carrinho == null)
            {
                return NotFound();
            }

            return carrinho;
        }

        // PUT: api/Carrinhos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrinho(int id, CarrinhoModel carrinho)
        {
            if (id != carrinho.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrinho.toEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrinhoExists(id))
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

        // POST: api/Carrinhos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrinho>> PostCarrinho(CarrinhoModel carrinho)
        {
            _context.Carrinho.Add(carrinho.toEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrinho", new { id = carrinho.Id }, carrinho);
        }

        // DELETE: api/Carrinhos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrinho(int id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }

            _context.Carrinho.Remove(carrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [Route("{clienteId}/cliente")]
        [HttpGet]
        public IActionResult GetCarrinhoporCliente(int clienteId)
        {
            var carrinho = _context.Carrinho.Where(x => x.ClienteId == clienteId)
                                            .Include(x => x.CarrinhoProduto)
                                            .Select(x => new 
                                            {
                                                ClienteId = x.ClienteId,
                                                Id = x.Id,
                                                Desconto = x.Desconto,
                                                Frete = x.Frete,
                                                PrecoFinal = x.PrecoFinal,
                                                CarrinhoProduto = x.CarrinhoProduto,
                                            })
                                            .FirstOrDefault();

            return Ok(carrinho);
        }

        private bool CarrinhoExists(int id)
        {
            return _context.Carrinho.Any(e => e.Id == id);
        }

        [Route("{clienteId}/carrinho")]
        [HttpPost]
        public IActionResult AddCarrinhoProduto([FromBody] CarrinhoProdutoRequest request, int clienteId)
        {
            var produto = _context.Produtos.Where(x=> x.Id == request.produtoId).FirstOrDefault();
            if (produto == null)
            {
                return NotFound();
            }

            //todo validar se tem produto no carrinho
            var carrinho = _context.Carrinho.Where(x => x.ClienteId == clienteId).FirstOrDefault();

            var carrinhoProduto = new CarrinhoProdutos()
            {
                ProdutoId = request.produtoId,
                Quantidade = request.quantidade,
                Carrinho = carrinho,
                CarrinhoId = carrinho.Id,
                Produto = produto,
            };

            _context.CarrinhoProdutos.Add(carrinhoProduto);
            _context.SaveChanges();

            return Ok();
           
        }

        [Route("{clienteId}/carrinho")]
        [HttpDelete]
        public IActionResult DeleteProdutoCarrinho(int produtoId,int clienteId)
        {
            var carrinhoProduto = _context.CarrinhoProdutos.Include(x => x.Carrinho)
                .Where(x => x.ProdutoId == produtoId && x.Carrinho.ClienteId == clienteId).FirstOrDefault();

            _context.CarrinhoProdutos.Remove(carrinhoProduto);
            _context.SaveChanges();

            return Ok();
        }


    }
}

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

            
            var carrinho = _context.Carrinho.Where(x => x.ClienteId == clienteId).FirstOrDefault();

            var carrinhoProduto = _context.CarrinhoProdutos.Where(x => x.ProdutoId == request.produtoId).FirstOrDefault();

            if(carrinhoProduto == null)
            {
                 carrinhoProduto = new CarrinhoProduto()
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

            carrinhoProduto.Quantidade = request.quantidade;

            _context.Entry(carrinhoProduto).State = EntityState.Modified;
            _context.SaveChanges();

            /*
            var carrinhoProduto = new CarrinhoProduto()
            {
                ProdutoId = request.produtoId,
                Quantidade = request.quantidade,
                Carrinho = carrinho,
                CarrinhoId = carrinho.Id,
                Produto = produto,
            };

            _context.CarrinhoProdutos.Add(carrinhoProduto);
            _context.SaveChanges();*/

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

        /// <summary>
        /// Passa do Carrinho para o Pedido
        /// </summary>
        [Route("{carrinhoId}/efetivarcompra")]
        [HttpPost]
        public IActionResult EfetivaComprar(int carrinhoId, EfetivaCompraRequest request)
        {
            var pedido = _context.Carrinho.Where(x => x.Id == carrinhoId)
              .Include(x => x.CarrinhoProduto)
                  //O iclude é basicamente um innerjoy (Não usar,apenas em casos bem simples)
                  .ThenInclude(x => x.Produto)
              .Select(x => new Pedido
              {
                  Id = 0,
                  ClienteId = x.ClienteId,
                  Frete = x.Frete,
                  PrecoFinal = x.PrecoFinal,
                  Desconto = x.Desconto,
                  EnderecoCobrancaId = request.EnderecoCobrancaId,
                  EnderecoEntregaId = request.EnderecoEntregaId,
                  CartaoCreditoId = request.CartaoId,

                    //PedidoProdutos = x.CarrinhoProduto.Select(y => new PedidoProduto
                    //{
                    //    Id = 0,
                    //    PedidoId = 0,
                    //    quantidade = y.Quantidade,
                    //    precoProduto = y.Produto.Preco,

                    //}).ToList(),
                    Status = StatusPedido.Processamento.ToString(),


              }).FirstOrDefault();

            _context.Pedido.Add(pedido);
            _context.SaveChanges();


            var pedidoid = _context.Pedido.Where(x => x.ClienteId == pedido.ClienteId)
                .Max(x => x.Id);

            var pedidoprodutos = _context.CarrinhoProdutos.Where(x => x.CarrinhoId == carrinhoId)
              .Include(x => x.Produto)
              .Select(x => new PedidoProduto
              {
                  Id = 0,
                  PedidoId = pedidoid,
                  quantidade = x.Quantidade,
                  precoProduto = x.Produto.Preco,
                  ProdutoId = x.ProdutoId,

              }).ToList();

            _context.PedidoProdutos.AddRange(pedidoprodutos);
            _context.SaveChanges();

            return Ok();
        }


    }
}

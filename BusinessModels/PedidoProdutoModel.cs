using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class PedidoProdutoModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int quantidade { get; set; }
        public double precoProduto { get; set; }
        public PedidoModel? Pedido { get; set; }
        public ProdutoModel? Produto { get; set; }

        public PedidoProduto toEntity()
        {
            return new PedidoProduto
            {
                Id = Id,
                PedidoId = PedidoId,
                ProdutoId = ProdutoId,
                quantidade = quantidade,
                precoProduto = precoProduto,
                Pedido = Pedido.toEntity(),
                Produto = Produto.toEntity()
            };
        }
    }
}

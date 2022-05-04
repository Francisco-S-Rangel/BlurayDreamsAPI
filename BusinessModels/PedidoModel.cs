using BlurayDreamsAPI.Models;
using System.Text.Json.Serialization;

namespace BlurayDreamsAPI.BusinessModels
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int? EnderecoCobrancaId { get; set; }
        public int? EnderecoEntregaId { get; set; }
        public int? CartaoCreditoId { get; set; }
        public int? CartaoCreditoId2 { get; set; }
        public int? CartaoCreditoId3 { get; set; }
        public double Desconto { get; set; }
        public double Frete { get; set; }
        public double PrecoFinal { get; set; }
        public string Status { get; set; }
        public DateTime? DataPedido { get; set; }
        [JsonIgnore]
        public virtual Cliente? cliente { get; set; }
        [JsonIgnore]
        public virtual EnderecoCobranca? enderecoCobranca { get; set; }
        [JsonIgnore]
        public virtual EnderecoEntrega? enderecoEntrega { get; set; }
        [JsonIgnore]
        public virtual CartaoCredito? cartaoCredito { get; set; }
        [JsonIgnore]
        public List<PedidoProdutoModel>? PedidoProdutos { get; set; }

        public Pedido toEntity()
        {
            return new Pedido
            {
                Id = Id,
                ClienteId = ClienteId,
                EnderecoCobrancaId = EnderecoCobrancaId,
                EnderecoEntregaId = EnderecoEntregaId,
                CartaoCreditoId = CartaoCreditoId,
                CartaoCreditoId2 = CartaoCreditoId2,
                CartaoCreditoId3 = CartaoCreditoId3,
                Desconto = Desconto,
                Frete = Frete,
                PrecoFinal = PrecoFinal,
                Status = Status,
                DataPedido = DateTime.UtcNow.Date,
                cliente = null,
                enderecoCobranca = null,
                enderecoEntrega = null,
                cartaoCredito = null,
                PedidoProdutos= PedidoProdutos != null ? PedidoProdutos.Select(x => x.toEntity()).ToList() : new List<PedidoProduto>(),
            };
        }

    }
}

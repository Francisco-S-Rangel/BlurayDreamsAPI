using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EnderecoCobrancaId { get; set; }
        public int EnderecoEntregaId { get; set; }
        public int CartaoID { get; set; }
        public double Desconto { get; set; }
        public double Frete { get; set; }
        public double PrecoFinal { get; set; }
        public virtual Cliente? cliente { get; set; }
        public virtual EnderecoCobranca? enderecoCobranca { get; set; }
        public virtual EnderecoEntrega? enderecoEntrega { get; set; }
        public virtual CartaoCredito? cartaoCredito { get; set; }

        public List<ProdutoModel>? Produtos { get; set; }

        public Pedido toEntity()
        {
            return new Pedido
            {
                Id = Id,
                ClienteId = ClienteId,
                EnderecoCobrancaId = EnderecoCobrancaId,
                EnderecoEntregaId = EnderecoEntregaId,
                CartaoID = CartaoID,
                Desconto = Desconto,
                Frete = Frete,
                PrecoFinal = PrecoFinal,
                cliente = null,
                enderecoCobranca = null,
                enderecoEntrega = null,
                cartaoCredito = null,
                Produtos = Produtos != null ? Produtos.Select(x => x.toEntity()).ToList() : new List<Produto>(),

            };
        }
    }
}

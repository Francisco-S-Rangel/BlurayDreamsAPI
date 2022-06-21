namespace BlurayDreamsAPI.Utilities
{
    public class EfetivaCompraRequest
    {
        public int EnderecoCobrancaId { get; set; }
        public int EnderecoEntregaId { get; set; }
        public int CartaoId { get; set; }
        public int CartaoId2 { get; set; }
        public int CartaoId3 { get; set; }
    }
    public class TrocaRequest
    { 
        public int PedidoId { get; set; }
        public int PedidoProdutoId { get; set; }
        public int Quantidadde { get; set; }
    }
}

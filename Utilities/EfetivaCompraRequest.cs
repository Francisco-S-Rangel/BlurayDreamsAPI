namespace BlurayDreamsAPI.Utilities
{
    public class EfetivaCompraRequest
    {
        public int EnderecoCobrancaId { get; set; }
        public int EnderecoEntregaId { get; set; }
        public int CartaoId { get; set; }
    }
    public class TrocaRequest
    { 
        public int PedidoProdutoId { get; set; }
        public int Quantidadde { get; set; }
    }
}

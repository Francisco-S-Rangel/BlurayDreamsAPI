using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class AtivacaoProdutoModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string MotivoAtivacao { get; set; }
        public Produto? Produto { get; set; }

        public AtivacaoProduto toEntity()
        {
            return new AtivacaoProduto
            {
                Id = Id,
                ProdutoId = ProdutoId,
                MotivoAtivacao = MotivoAtivacao,
                Produto = null,
            };
        }
    }
}

using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class CarrinhoProdutoModel
    {
        
        public int Id { get; set; }
       
        public int CarrinhoId { get; set; }
      
        public int ProdutoId { get; set; }
       
        public int Quantidade { get; set; }

        public CarrinhoModel Carrinho { get; set; }

        public ProdutoModel Produto { get; set; }

        public CarrinhoProduto toEntity()
        {
            return new CarrinhoProduto
            {
                Id = Id,
                CarrinhoId = CarrinhoId,
                ProdutoId = ProdutoId,
                Quantidade = Quantidade,
                Carrinho = Carrinho.toEntity(),
                Produto = Produto.toEntity(),
            };
        }
    }
}

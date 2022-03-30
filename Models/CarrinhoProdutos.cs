using System.ComponentModel.DataAnnotations;

namespace BlurayDreamsAPI.Models
{
    public class CarrinhoProdutos
    {
        [key]
        public int Id { get; set; }
        [Required]
        public int CarrinhoId { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int Quantidade { get; set; }

        public Carrinho Carrinho { get; set; }
    
        public Produto Produto { get; set; }

    }
}

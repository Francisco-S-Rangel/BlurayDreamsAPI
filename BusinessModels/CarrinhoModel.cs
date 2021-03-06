using BlurayDreamsAPI.Models;
using System.Text.Json.Serialization;

namespace BlurayDreamsAPI.BusinessModels
{
    public class CarrinhoModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public double Desconto { get; set; }
        public double Frete { get; set; }
        public double PrecoFinal { get; set; }
        [JsonIgnore]
        public virtual Cliente? cliente { get; set; }
       
        public List<CarrinhoProdutoModel>? CarrinhoProduto { get; set; }

        public Carrinho toEntity()
        {
            return new Carrinho
            {
                Id = Id,
                ClienteId = ClienteId,
                Desconto = Desconto,
                PrecoFinal = PrecoFinal,
                Frete = Frete,
                cliente = null,
                CarrinhoProduto = CarrinhoProduto != null ? CarrinhoProduto.Select(x => x.toEntity()).ToList() : new List<CarrinhoProduto>(),

            };

        }


    }
}

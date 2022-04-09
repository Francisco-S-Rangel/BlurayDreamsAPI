using BlurayDreamsAPI.Models;
using System.Text.Json.Serialization;

namespace BlurayDreamsAPI.BusinessModels
{
    public class DesativacaoProdutoModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string MotivoDesativacao { get; set; }
        [JsonIgnore]
        public Produto? Produto { get; set; }

        public DesativacaoProduto toEntity()
        {
            return new DesativacaoProduto
            {
                Id = Id,
                ProdutoId = ProdutoId,
                MotivoDesativacao = MotivoDesativacao,
                Produto = null,
            };
        }
    }
}


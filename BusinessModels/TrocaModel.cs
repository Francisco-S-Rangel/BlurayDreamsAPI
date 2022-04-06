using BlurayDreamsAPI.Models;
using System.Text.Json.Serialization;

namespace BlurayDreamsAPI.BusinessModels
{
    public class TrocaModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int PedidoProdutoId { get; set; }
        public string Status { get; set; }
        public Boolean RecebimentoProduto { get; set; }
        public int Quantidade { get; set; }

        [JsonIgnore]
        public ClienteModel? Cliente { get; set; }
        [JsonIgnore]
        public PedidoProdutoModel? PedidoProduto { get; set; }

        public Troca toEntity()
        {
            return new Troca
            {
                Id = Id,
                ClienteId = ClienteId,
                PedidoProdutoId = PedidoProdutoId,
                Status = Status,
                RecebimentoProduto = RecebimentoProduto,
                Quantidade = Quantidade,
                Cliente = null,
                PedidoProduto = null,

            };
        }
    }
}

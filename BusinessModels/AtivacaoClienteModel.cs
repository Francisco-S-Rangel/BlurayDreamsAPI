using BlurayDreamsAPI.Models;
using System.Text.Json.Serialization;

namespace BlurayDreamsAPI.BusinessModels
{
    public class AtivacaoClienteModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string MotivoAtivacao { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        public AtivacaoCliente toEntity()
        {
            return new AtivacaoCliente
            {
                Id = Id,
                ClienteId = ClienteId,
                MotivoAtivacao = MotivoAtivacao,
                Cliente = null,
            };
        }
    }
}

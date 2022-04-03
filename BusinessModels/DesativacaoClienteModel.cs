using BlurayDreamsAPI.Models;
using System.Text.Json.Serialization;

namespace BlurayDreamsAPI.BusinessModels
{
    public class DesativacaoClienteModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string MotivoDesativacao { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        public DesativacaoCliente toEntity()
        {
            return new DesativacaoCliente {
                Id = Id,
                ClienteId = ClienteId,
                MotivoDesativacao = MotivoDesativacao,
                Cliente = null,
            };
        }
    }
}

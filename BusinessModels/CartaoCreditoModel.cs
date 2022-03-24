using BlurayDreamsAPI.Models;
using System.Text.Json.Serialization;

namespace BlurayDreamsAPI.BusinessModels
{
    public class CartaoCreditoModel
    {
        public int Id { get; set; }
        
        public int ClienteId { get; set; }
       
        public string NumeroCartao { get; set; }
       
        public string BandeiraCartao { get; set; }
     
        public string CVV { get; set; }
       
        public string NomeTitular { get; set; }

        [JsonIgnore]
        public virtual Cliente? cliente { get; set; }

        public CartaoCredito toEntity()
        {
            return new CartaoCredito
            {
                Id = Id,
                ClienteId = ClienteId,
                NumeroCartao = NumeroCartao,
                BandeiraCartao = BandeiraCartao,
                CVV = CVV,
                NomeTitular = NomeTitular,
                cliente = null,
             

            };
        }


    }
}

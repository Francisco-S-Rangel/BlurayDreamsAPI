using BlurayDreamsAPI.Models;

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

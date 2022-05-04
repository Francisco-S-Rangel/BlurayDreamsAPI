using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class CupomClienteModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int CupomId { get; set; }

        public ClienteModel? Cliente { get; set; }
        public CupomModel? Cupom { get; set; }

        public CupomCliente toEntity()
        {
            return new CupomCliente
            {
                Id = Id,
                ClienteId = ClienteId,
                CupomId = CupomId,
                Cliente = null,
                Cupom = null,
            };
        }
    }
}

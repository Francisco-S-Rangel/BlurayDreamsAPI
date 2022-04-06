using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class CupomModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public double TamanhoDesconto { get; set; }
        public string Codigo { get; set; }

        public Cupom toEntity()
        {
            return new Cupom
            {
                Id = Id,
                Tipo = Tipo,
                TamanhoDesconto = TamanhoDesconto,
                Codigo = Codigo
            };
        }

    }
}

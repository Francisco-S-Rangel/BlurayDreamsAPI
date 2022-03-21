using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class EnderecoEntregaModel
    {
        public int Id { get; set; }
      
        public int ClienteId { get; set; }
        
        public string CEP { get; set; }
     
        public string TipoResidencia { get; set; }
      
        public string Logradouro { get; set; }
       
        public string TipoLogradouro { get; set; }
     
        public string Bairro { get; set; }
       
        public string Cidade { get; set; }
       
        public string Estado { get; set; }
      
        public string Pais { get; set; }
      
        public string Numero { get; set; }
    
        public string Apelido { get; set; }

        public string? Observacao { get; set; }

        public virtual Cliente? cliente { get; set; }

        public EnderecoEntrega toEntity()
        {
            return new EnderecoEntrega
            {
                Id = Id,
                ClienteId = ClienteId,
                CEP = CEP,
                TipoLogradouro = TipoLogradouro,
                Logradouro = Logradouro,
                Bairro = Bairro,
                Cidade = Cidade,
                Estado = Estado,
                Pais = Pais,
                Numero = Numero,
                cliente = null,
                TipoResidencia = TipoResidencia,
                Apelido = Apelido,
                Observacao = Observacao,

            };
        }
    }
}

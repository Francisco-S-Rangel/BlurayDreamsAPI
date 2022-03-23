using BlurayDreamsAPI.BusinessModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class EnderecoCobranca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string TipoResidencia { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string TipoLogradouro { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Numero { get; set; }

        public virtual Cliente cliente { get; set; }

        public EnderecoCobrancaModel toModel()
        {
            return new EnderecoCobrancaModel
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

            };
        }

    }
    
}

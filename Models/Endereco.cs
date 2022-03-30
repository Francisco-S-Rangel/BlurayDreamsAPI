using BlurayDreamsAPI.BusinessModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FuncionarioId { get; set; }
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

        [JsonIgnore]
        public  Funcionario? Funcionario { get; set; }

        public EnderecoModel toModel()
        {
            return new EnderecoModel
            {
                Id = Id,
               FuncionarioId = FuncionarioId,
                CEP = CEP,
                TipoLogradouro = TipoLogradouro,
                Logradouro = Logradouro,
                Bairro = Bairro,
                Cidade = Cidade,
                Estado = Estado,
                Pais = Pais,
                Numero = Numero,
                Funcionario = null,
                TipoResidencia = TipoResidencia,

            };
        }
    }
}

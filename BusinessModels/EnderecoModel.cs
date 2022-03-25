using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class EnderecoModel
    {
        public int Id { get; set; }

        public int FuncionarioId { get; set; }

        public string CEP { get; set; }

        public string TipoResidencia { get; set; }

        public string Logradouro { get; set; }

        public string TipoLogradouro { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public string Numero { get; set; }

        public virtual Funcionario? Funcionario { get; set; }

        public Endereco toEntity()
        {
            return new Endereco
            {
                Id = Id,
                Funcionario = null,
                CEP = CEP,
                TipoLogradouro = TipoLogradouro,
                Logradouro = Logradouro,
                Bairro = Bairro,
                Cidade = Cidade,
                Estado = Estado,
                Pais = Pais,
                Numero = Numero,
                FuncionarioId = FuncionarioId,
                TipoResidencia = TipoResidencia,

            };
        }

    }
}

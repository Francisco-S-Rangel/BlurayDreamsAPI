using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string TipoTelefone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Boolean Status { get; set; }

        public EnderecoModel? Endereco { get; set; }


        public Funcionario toEntity()
        {
            return new Funcionario
            {
                Id = Id,
                Nome = Nome,
                DataNascimento = DataNascimento,
                DDD = DDD,
                Telefone = Telefone,
                TipoTelefone = TipoTelefone,
                CPF = CPF,
                Email = Email,
                Senha = Senha,
                Status = Status,
                Endereco = Endereco != null ? Endereco.toEntity() : new Endereco(),
            };
        }
    }
}

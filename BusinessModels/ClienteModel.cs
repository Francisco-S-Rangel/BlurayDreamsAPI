using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
        public class ClienteModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string DataNascimento { get; set; }
            public string DDD { get; set; }
            public string Telefone { get; set; }
            public string TipoTelefone { get; set; }
            public string CPF { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }

            public List<EnderecoCobrancaModel>? EnderecoCobrancas { get; set; }
            public List<EnderecoEntregaModel>? EnderecoEntregas { get; set; }
            public List<CartaoCreditoModel>? CartaoCreditos { get; set; }

        public Cliente toEntity()
        {
            return new Cliente
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
                EnderecoCobrancas = EnderecoCobrancas != null ? EnderecoCobrancas.Select(x => x.toEntity()).ToList() : new List<EnderecoCobranca>(),
                EnderecoEntregas = EnderecoEntregas != null  ? EnderecoEntregas.Select(x => x.toEntity()).ToList() : new List<EnderecoEntrega> (),
                CartaoCreditos = CartaoCreditos != null  ? CartaoCreditos.Select(x => x.toEntity()).ToList() : new List<CartaoCredito>(),
                

            };
        }



    }
    
}

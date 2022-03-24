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
    }
}

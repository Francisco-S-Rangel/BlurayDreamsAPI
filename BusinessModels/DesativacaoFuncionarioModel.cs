using BlurayDreamsAPI.Models;
using Newtonsoft.Json;

namespace BlurayDreamsAPI.BusinessModels
{
    public class DesativacaoFuncionarioModel
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public string MotivoDesativacao { get; set; }
        [JsonIgnore]
        public Funcionario? Funcionario { get; set; }

        public DesativacaoFuncionario toEntity()
        {
            return new DesativacaoFuncionario
            {
                Id = Id,
                FuncionarioId = FuncionarioId,
                MotivoDesativacao = MotivoDesativacao,
                Funcionario = null,
            };
        }
    }
}

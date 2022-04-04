using BlurayDreamsAPI.Models;
using System.Text.Json.Serialization;

namespace BlurayDreamsAPI.BusinessModels
{
    public class AtivacaoFuncionarioModel
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public string MotivoAtivacao { get; set; }
        [JsonIgnore]
        public Funcionario? Funcionario { get; set; }

        public AtivacaoFuncionario toEntity()
        {
            return new AtivacaoFuncionario
            {
                Id = Id,
                FuncionarioId = FuncionarioId,
                MotivoAtivacao = MotivoAtivacao,
                Funcionario = null,
            };
        }
    }
}

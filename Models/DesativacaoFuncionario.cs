using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class DesativacaoFuncionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FuncionarioId { get; set; }
        [Required]
        public string MotivoDesativacao { get; set; }
        [Required]
        public Funcionario Funcionario { get; set; }
    }
}

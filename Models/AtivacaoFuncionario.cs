using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class AtivacaoFuncionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FuncionarioId { get; set; }
        [Required]
        public string MotivoAtivacao { get; set; }
        [Required]
        public Funcionario Funcionario { get; set; }
    }
}

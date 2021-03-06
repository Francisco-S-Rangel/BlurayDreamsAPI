using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class AtivacaoCliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public string MotivoAtivacao { get; set; }
        [Required]
        public Cliente Cliente { get; set; }

    }
}

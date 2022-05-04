using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class CupomCliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int CupomId { get; set; }

        public Cliente Cliente { get; set; }
        public Cupom Cupom { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class Cupom
    {
     [Key]
     public int Id { get; set; }
     [Required]
     public string Tipo { get; set; }
     [Required]
     public double TamanhoDesconto { get; set; }
     [Required]
     public string Codigo { get; set; }

    }
}

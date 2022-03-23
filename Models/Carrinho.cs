using BlurayDreamsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public double Desconto { get; set; }
        [Required]
        public double Frete { get; set; }
        [Required]
        public double PrecoFinal { get; set; }
        public virtual Cliente cliente { get; set; }

        public List<Produto>? Produtos { get; set; }

    }
}

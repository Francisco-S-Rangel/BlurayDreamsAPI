using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class CartaoCredito
    {
        [Required]
        public string NumeroCartao { get; set; }
        [Required]
        public string BandeiraCartao { get; set; }
        [Required]
        public string CVV { get; set; }
        [Required]
        public string NomeTitular { get; set; }
    }
}

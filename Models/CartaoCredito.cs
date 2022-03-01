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
         [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public string NumeroCartao { get; set; }
        [Required]
        public int BandeiraCartaoId { get; set; }
        [Required]
        public string CVV { get; set; }
        [Required]
        public string NomeTitular { get; set; }
        public BandeiraCartao BandeiraCartao { get; set; }
        public Cliente Cliente { get; set; }
    }
}

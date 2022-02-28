using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace BlurayDreamsAPI.Models
{
    public class Cliente
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string EnderecoResidencial { get; set; }
        [Required]
        public string Senha { get; set; }
        public List<EnderecoEntrega> EnderecoEntregas { get; set; }
        public List<EnderecoCobranca> EnderecoCobrancas { get; set; }
        public List<CartaoCredito>? CartaoCreditos { get; set; }

    }
}

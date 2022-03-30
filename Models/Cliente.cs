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
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string DDD { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string TipoTelefone { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public Boolean Status { get; set; }

        public Carrinho carrinho { get; set; }
   
        public List<EnderecoCobranca> EnderecoCobrancas { get; set; }
        public List<EnderecoEntrega> EnderecoEntregas { get; set; }
        public List<CartaoCredito>? CartaoCreditos { get; set; }
        public List<Pedido>? Pedidos { get; set; }

    }

}

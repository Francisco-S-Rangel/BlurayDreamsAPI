using BlurayDreamsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int EnderecoCobrancaId { get; set; }
        [Required]
        public int EnderecoEntregaId { get; set; }
        [Required]
        public int CartaoID { get; set; }
        [Required]
        public double Desconto { get; set; }
        [Required]
        public double Frete { get; set; }
        [Required]
        public double PrecoFinal { get; set; }
        [Required]
        public virtual Cliente cliente { get; set; }
        [Required]
        public virtual EnderecoCobranca enderecoCobranca { get; set; }
        [Required]
        public virtual EnderecoEntrega enderecoEntrega { get; set; }
        [Required]
        public virtual CartaoCredito cartaoCredito { get; set; }

        public List<Produto> Produtos { get; set; }


    }
}

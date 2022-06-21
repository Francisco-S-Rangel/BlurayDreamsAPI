using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class Troca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int PedidoId { get; set; }
        [Required]
        public int PedidoProdutoId { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public Boolean RecebimentoProduto { get; set; }
        [Required]
        public int Quantidade { get; set; }

        public Cliente Cliente { get; set; }
        public PedidoProduto PedidoProduto { get; set; }
        public Pedido Pedido { get; set; }
    }
}

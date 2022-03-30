using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class PedidoProduto
    {
        [key]
        public int Id { get; set; }
        [Required]
        public int PedidoId { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int quantidade { get; set; }
        [Required]
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}

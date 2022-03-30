using BlurayDreamsAPI.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
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
        public int CartaoCreditoId { get; set; }
        [Required]
        public double Desconto { get; set; }
        [Required]
        public double Frete { get; set; }
        [Required]
        public double PrecoFinal { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [JsonIgnore]
        public virtual Cliente cliente { get; set; }
        [Required]
        [JsonIgnore]
        public virtual EnderecoCobranca enderecoCobranca { get; set; }
        [Required]
        [JsonIgnore]
        public virtual EnderecoEntrega enderecoEntrega { get; set; }
        [Required]
        [JsonIgnore]
        public virtual CartaoCredito cartaoCredito { get; set; }
        [JsonIgnore]
        public List<PedidoProduto> PedidoProdutos { get; set; }


    }
}

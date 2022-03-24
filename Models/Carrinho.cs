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
        [JsonIgnore]
        public virtual Cliente? cliente { get; set; }
        [JsonIgnore]
        public List<Produto>? Produtos { get; set; }

        public Carrinho() { }
        public Carrinho(int clienteid)
        {
            this.ClienteId = clienteid;
            this.cliente = null;
            this.Produtos = Produtos != null ? Produtos.ToList() : new List<Produto>();

        }
    }
}

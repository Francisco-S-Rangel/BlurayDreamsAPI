using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public string tipo { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Ano { get; set; }
        [Required]
        public string Direcao { get; set; }
        [Required]
        public string Duracao { get; set; }
        [Required]
        public string Produtora { get; set; }
        [Required]
        public string Sinopse { get; set; }


    }
}

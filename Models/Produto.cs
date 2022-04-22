using BlurayDreamsAPI.BusinessModels;
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
        public string Tipo { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public DateTime Ano { get; set; }
        [Required]
        public string Direcao { get; set; }
        [Required]
        public string Duracao { get; set; }
        [Required]
        public string Produtora { get; set; }
        [Required]
        public string Sinopse { get; set; }
        [Required]
        public Boolean Status { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public int Estoque { get; set; }

        public List<AtivacaoProduto>? AtivacaoProdutos { get; set; }
        public List<DesativacaoProduto>? DesativacaoProdutos { get; set; }

        public Produto() { }
        public Produto(int id,string titulo,string img,string tipo,string categoria,
            DateTime ano, string direcao,string duracao,string produtora, string sinopse, Boolean status, double preco
            , int estoque)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Img = img;
            this.Tipo = tipo;
            this.Categoria = categoria;
            this.Ano = ano;
            this.Direcao = direcao;
            this.Duracao = duracao;
            this.Produtora = produtora;
            this.Sinopse = sinopse;
            this.Status = status;
            this.Preco = preco;
            this.Estoque = estoque;

        }


    }
}

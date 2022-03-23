﻿using BlurayDreamsAPI.BusinessModels;
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

        public ProdutoModel toModel()
        {
            return new ProdutoModel
            {
                Id = Id,
                Titulo = Titulo,
                Img = Img,
                Tipo = Tipo,
                Categoria = Categoria,
                Ano = Ano,
                Direcao = Direcao,
                Duracao = Duracao,
                Produtora = Produtora,
                Sinopse = Sinopse,
                Status = Status,
                Preco = Preco,
                Estoque = Estoque
             

            };
        }


    }
}
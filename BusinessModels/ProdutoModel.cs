using BlurayDreamsAPI.Models;

namespace BlurayDreamsAPI.BusinessModels
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Img { get; set; }

        public string Tipo { get; set; }

        public string Categoria { get; set; }

        public DateTime Ano { get; set; }

        public string Direcao { get; set; }

        public string Duracao { get; set; }

        public string Produtora { get; set; }

        public string Sinopse { get; set; }

        public Boolean Status { get; set; }

        public double Preco { get; set; }

        public int Estoque { get; set; }

        public Produto toEntity()
        {
            return new Produto
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

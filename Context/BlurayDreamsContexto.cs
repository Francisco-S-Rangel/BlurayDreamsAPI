using BlurayDreamsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlurayDreamsAPI.Context
{
    public class BlurayDreamsContexto : DbContext
    {
        public BlurayDreamsContexto(DbContextOptions<BlurayDreamsContexto> options):base(options)
        {

        }

        public DbSet<Cliente>Clientes { get; set; }
        public DbSet<EnderecoCobranca> EnderecoCobrancas { get; set; }
        public DbSet<EnderecoEntrega> EnderecoEntregas { get; set; }
        public DbSet<CartaoCredito> CartaoCreditos { get; set; }
        public DbSet<BandeiraCartao> BandeiraCartaos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<BlurayDreamsAPI.Models.Carrinho> Carrinho { get; set; }
        public DbSet<BlurayDreamsAPI.Models.Pedido> Pedido { get; set; }
        public DbSet<CarrinhoProdutos> CarrinhoProdutos { get;set; }
        public DbSet<BlurayDreamsAPI.Models.Funcionario> Funcionario { get; set; }
        public DbSet<BlurayDreamsAPI.Models.Endereco> Endereco { get; set; }
    }
}

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
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<CartaoCredito> CartaoCreditos { get; set; }
        public DbSet<BandeiraCartao> BandeiraCartaos { get; set; }
    }
}

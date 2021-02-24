using EFCOre.WebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCOre.WebAPI.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }

        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) { }

        // No caso de utilizar uma relação Many to Many, é preciso indicar ao entity quais são as chaves compostas
        // para fazer a relação entre essas tabelas;
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HeroiBatalha>(entity =>
        //    {
        //        entity.HasKey(key => new { key.BatalhaId, key.HeroiId });
        //    });
        //}
    }
}

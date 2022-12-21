using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class HeroiContext : DbContext
    {
        //public HeroiContext()
        //{

        //}
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) { }

        public DbSet<Heroi> Herois { get; set; }

        public DbSet<Arma> Armas { get; set; }

        public DbSet<Batalha> Batalhas { get; set; }

        public DbSet<HeroiBatalha> HeroiBatalhas { get; set; }

        public DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=NOT-LEANDRO\\SQLExpress;Initial Catalog=HeroApp;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            });
        }
    }
}

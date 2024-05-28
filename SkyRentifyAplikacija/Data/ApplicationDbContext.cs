using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyRentifyAplikacija.Models;

namespace SkyRentifyAplikacija.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        public DbSet<Kaciga> Kaciga { get; set; }
        public DbSet<Pancerice> Pancerice { get; set; }
        public DbSet<Skije> Skije { get; set; }
        public DbSet<Snowboard> Snowboard { get; set; }
        public DbSet<SnowboardCipele> SnowboardCipele { get; set; }
        public DbSet<Stapovi> Stapovi { get; set; }
        public DbSet<StavkaZahtjeva> StavkaZahtjeva { get; set; }
        public DbSet<TipZahtjeva> TipZahtjeva { get; set; }
        public DbSet<TipoviZahtjeva> TipoviZahtjeva { get; set; }
        public DbSet<Uposlenik> Uposlenik { get; set; }
        public DbSet<Vlasnik> Vlasnik { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klijent>().ToTable("Klijent");
            modelBuilder.Entity<Zahtjev>().ToTable("Zahtjev");
            modelBuilder.Entity<Kaciga>().ToTable("Kaciga");
            modelBuilder.Entity<Pancerice>().ToTable("Pancerice");
            modelBuilder.Entity<Skije>().ToTable("Skije");
            modelBuilder.Entity<Snowboard>().ToTable("Snowboard");
            modelBuilder.Entity<SnowboardCipele>().ToTable("SnowboardCipele");
            modelBuilder.Entity<Stapovi>().ToTable("Stapovi");
            modelBuilder.Entity<StavkaZahtjeva>().ToTable("StavkaZahtjeva");
            modelBuilder.Entity<TipZahtjeva>().ToTable("TipZahtjeva");
            modelBuilder.Entity<TipoviZahtjeva>().ToTable("TipoviZahtjeva");
            modelBuilder.Entity<Uposlenik>().ToTable("Uposlenik");
            modelBuilder.Entity<Vlasnik>().ToTable("Vlasnik");

            //unosenje podataka za skije
            modelBuilder.Entity<Skije>().HasData(
                new Skije { Id = 1,cijena=20,marka="Atomic",materijal="Drvo",duzina=160,sirina=10 },
                new Skije { Id = 2,cijena=30,marka="Salomon",materijal="Plastika",duzina=170,sirina=15 }             
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

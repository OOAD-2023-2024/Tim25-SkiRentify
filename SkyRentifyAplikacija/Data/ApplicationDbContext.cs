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

            modelBuilder.Entity<Kaciga>().HasData(
                new Kaciga { Id = 4, cijena = 10, marka = "Atomic", materijal = "Drvo", velicina = 'M' },
                new Kaciga { Id = 5, cijena = 15, marka = "Salomon", materijal = "Plastika", velicina = 'L' },
                new Kaciga { Id = 6, cijena = 20, marka = "Fischer", materijal = "Drvo", velicina = 'S' },
                new Kaciga { Id = 7, cijena = 25, marka = "Salomon", materijal = "Plastika", velicina = 'M' },
                new Kaciga { Id = 8, cijena = 30, marka = "Atomic", materijal = "Drvo", velicina = 'L' });

            modelBuilder.Entity<Pancerice>().HasData(
                new Pancerice { Id = 9, cijena = 10, marka = "Atomic", materijal = "Drvo", velicina = 40 },
                new Pancerice { Id = 10, cijena = 15, marka = "Salomon", materijal = "Plastika", velicina = 41 },
                new Pancerice { Id = 11, cijena = 20, marka = "Fischer", materijal = "Drvo", velicina = 42 },
                new Pancerice { Id = 12, cijena = 25, marka = "Salomon", materijal = "Plastika", velicina = 39 });

            modelBuilder.Entity<Snowboard>().HasData(
                new Snowboard { Id = 13, cijena = 10, marka = "Atomic", materijal = "Drvo", duzina = 160 },
                new Snowboard { Id = 14, cijena = 15, marka = "Salomon", materijal = "Plastika", duzina = 170 },
                new Snowboard { Id = 15, cijena = 20, marka = "Fischer", materijal = "Drvo", duzina = 180 },
                new Snowboard { Id = 16, cijena = 25, marka = "Salomon", materijal = "Plastika", duzina = 190 },
                new Snowboard { Id=17, cijena=30, marka="Nordic",materijal="Drvo",duzina=200});

            base.OnModelCreating(modelBuilder);
        }
    }
}

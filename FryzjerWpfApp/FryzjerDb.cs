using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FryzjerWpfApp
{
    public class FryzjerDb : DbContext
    {
        public static FryzjerDb Instance = new FryzjerDb();

        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }

        public FryzjerDb()
        {
            //utwozenie jezeli nie istnieje
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FryzjerDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}

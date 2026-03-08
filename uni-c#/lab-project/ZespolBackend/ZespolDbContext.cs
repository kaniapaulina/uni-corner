using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace ZespolBackend
{
    
    public class ZespolDbContext : DbContext
    {
        public DbSet<Zespol> Zespoly { get; set; }
        public DbSet<KierownikZespolu> Kierownicy { get; set; }
        public DbSet<CzlonekZespolu> Czlonkowie { get; set; }

        public ZespolDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ZespolDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zespol>()
                .HasOne(z => z.KierownikZespolu)
                .WithMany() // Zakładamy, że kierownik może nie mieć listy zespołów
                .HasForeignKey(z => z.KierownikZespoluId);

            modelBuilder.Entity<CzlonekZespolu>()
                .HasOne(c => c.Zespol)
                .WithMany(z => z.CzlonkowieZespolu)
                .HasForeignKey(c => c.ZespolId);
        }

    }
    
}

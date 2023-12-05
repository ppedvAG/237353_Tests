using Microsoft.EntityFrameworkCore;
using ppedv.CubicleCarnival.Model;

namespace ppedv.CubicleCarnival.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }

        private string conString;

        public EfContext(string conString)
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            modelBuilder.Entity<Kunde>().ToTable("Kunde");
        }
    }
}

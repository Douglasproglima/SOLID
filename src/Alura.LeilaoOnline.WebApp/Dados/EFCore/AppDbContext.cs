using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class AppDbContext : DbContext
    {
        //private string connectionSqlServer = "Server=(localdb)\\MSSQLLocalDB;Database=AluraLeiloesDB;Trusted_Connection=true";
        private string connectionSqlServer = "Server=.\\SQLEXPRESS;Database=AluraLeiloesDB;User Id=sa;password=root;Trusted_Connection=true;MultipleActiveResultSets=true;Integrated Security=False";
        public DbSet<Leilao> Leiloes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionSqlServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leilao>()
                .HasOne(l => l.Categoria)
                .WithMany(c => c.Leiloes)
                .HasForeignKey(l => l.IdCategoria);
        }
    }
}
using CashTeste.Model;
using Microsoft.EntityFrameworkCore;

namespace CashTeste.Domain
{
	public class AppContext : DbContext
	{
		public DbSet<CashValores> CashValores { get; set; }
		public DbSet<Discos> Discos { get; set; }
		public DbSet<Vendas> Vendas { get; set; }

		public AppContext(DbContextOptions<AppContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CashValores>().ToTable("CashValores");
			modelBuilder.Entity<Discos>().ToTable("Discos");
			modelBuilder.Entity<Vendas>().ToTable("Vendas");
		}
	}
}

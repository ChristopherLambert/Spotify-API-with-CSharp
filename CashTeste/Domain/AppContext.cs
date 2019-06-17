using CashTeste.Model;
using Microsoft.EntityFrameworkCore;

namespace CashTeste.Domain
{
	public class AppContext : DbContext
	{
		public DbSet<CashValores> CashValores { get; set; }

		public AppContext(DbContextOptions<AppContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CashValores>().ToTable("CashValores");
		}
	}
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashTeste.Model
{
	public class Vendas
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime? DataVenda { get; set; }
		public decimal CashBack { get; set; }
		public decimal ValorVenda { get; set; }
	}
}

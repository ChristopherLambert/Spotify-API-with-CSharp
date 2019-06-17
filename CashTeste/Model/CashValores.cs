using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashTeste.Model
{
	public class CashValores
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Dia { get; set; }
		public string Genero { get; set; }
		public decimal Valor { get; set; }
	}
}

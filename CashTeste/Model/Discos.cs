using System.ComponentModel.DataAnnotations.Schema;

namespace CashTeste.Model
{
	public class Discos
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Genero { get; set; }
		public string Nome { get; set; }
		public decimal Valor { get; set; }
	}
}

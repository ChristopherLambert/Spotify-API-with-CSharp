using System;

namespace CashTeste.DTO
{
	public class FiltroVendas
	{
		public EnumVendas VendasFiltro { get; set; }

		public int Id { get; set; }

		public string DataVendaInicio { get; set; }

		public string DataVendaFim { get; set; }

		//Paginação
		public int PaginacaoLimit { get; set; }

		public int PaginaNumero { get; set; }
	}
}

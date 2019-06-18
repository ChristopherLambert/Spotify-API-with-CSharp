using CashTeste.DTO;
using CashTeste.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CashTeste.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VendasController : ControllerBase
	{
		private readonly Domain.AppContext _context;

		public VendasController(Domain.AppContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<object>> Get([FromQuery]FiltroVendas filtro)
		{
			try
			{
				if (filtro.PaginacaoLimit == 0)
					filtro.PaginacaoLimit = 10;

				var indexInicial = filtro.PaginacaoLimit * filtro.PaginaNumero;
				var indexFinal = indexInicial + filtro.PaginacaoLimit;

				if (filtro.VendasFiltro == EnumVendas.Todos)
				{
					var vendas = _context.Vendas.ToList();
					var vendasRetorno = new List<Vendas>();

					for (int i = indexInicial; i < indexFinal; i++)
					{
						if (i < vendas.Count)
							vendasRetorno.Add(vendas[i]);
					}

					return this.Ok(vendasRetorno);
				}
				else if (filtro.VendasFiltro == EnumVendas.Id)
				{
					var resultado = _context.Vendas.Where(c => c.Id == filtro.Id).FirstOrDefault();
					return this.Ok(resultado);
				}
				else if (filtro.VendasFiltro == EnumVendas.DataVenda)
				{
					var vendas = _context.Vendas.Where(c => c.DataVenda >= ConvertDate(filtro.DataVendaInicio)
						&& c.DataVenda <= ConvertDate(filtro.DataVendaFim).AddDays(1).AddMinutes(-1)).ToList();
					var vendasRetorno = new List<Vendas>();

					for (int i = indexInicial; i < indexFinal; i++)
					{
						if (i < vendas.Count)
							vendasRetorno.Add(vendas[i]);
					}

					vendasRetorno = vendasRetorno.OrderBy(c => c.DataVenda).ToList();
					return this.Ok(vendasRetorno);
				}

				return this.Ok("Falha no seu filtro!");
			}
			catch (Exception ex)
			{
				return this.Ok("Falha no seu filtro!");
			}
		}

		[HttpPost]
		public async Task<ActionResult<object>> Post([FromBody]List<int> IdsDisco)
		{
			try
			{
				var dataAtual = DateTime.Now;
				var vendasTotais = new List<Vendas>();
				decimal cashBackTotal = 0;

				foreach (var id in IdsDisco)
				{
					var disco = _context.Discos.Where(c => c.Id == id).FirstOrDefault();
					var cash = _context.CashValores.Where(c => c.Genero == disco.Genero.ToUpper()
					&& c.Dia == ((int)dataAtual.DayOfWeek + 1)).FirstOrDefault();

					decimal cashBack = cash.Valor * disco.Valor;
					Vendas venda = new Vendas()
					{
						DataVenda = dataAtual,
						CashBack = cashBack,
						ValorVenda = disco.Valor - cashBack
					};

					cashBackTotal = cashBackTotal + cashBack;
					vendasTotais.Add(venda);
				}

				foreach (var venda in vendasTotais)
				{
					_context.Vendas.Add(venda);
				}

				_context.SaveChanges();

				return this.Ok(new { CashBackTotal = cashBackTotal, vendas = vendasTotais });
			}
			catch (Exception ex)
			{
				return this.Ok("Falha ao executar sua venda!");
			}
		}

		private DateTime ConvertDate(string date)
		{
			var culture = new CultureInfo("pt-BR");
			return Convert.ToDateTime(date, culture);
		}
	}
}

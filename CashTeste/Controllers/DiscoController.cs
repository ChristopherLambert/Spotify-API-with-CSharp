using CashTeste.Domain;
using CashTeste.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CashTeste.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscoController : ControllerBase
	{
		private readonly Domain.AppContext _context;

		public DiscoController(Domain.AppContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<object>> Get([FromQuery]FiltroDiscos filtro)
		{
			try
			{
				if (filtro.DiscosFiltro == EnumDiscos.Todos)
				{
					return this.Ok(_context.Discos.ToList());
				}
				else if (filtro.DiscosFiltro == EnumDiscos.Categorias)
				{
					var resultado = _context.Discos.Where(c => c.Genero.Equals(filtro.Categoria.ToUpper())).ToList();
					return this.Ok(resultado);
				}
				else if (filtro.DiscosFiltro == EnumDiscos.Id)
				{
					var resultado = _context.Discos.Where(c => c.Id == filtro.Id).FirstOrDefault();
					return this.Ok(resultado);
				}

				return this.Ok("Falha no seu filtro!");
			}
			catch (Exception ex)
			{
				return this.Ok("Falha no seu filtro!");
			}	
		}
	}
}

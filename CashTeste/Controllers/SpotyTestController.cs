using CashTeste.DTO;
using CashTeste.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CashTeste.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpotyTestController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<object>> Get([FromQuery]FiltroSpoty filtro)
		{
			SpotyRest.StartCredentialsAuth();

			if (filtro.SpotyFiltro == EnumSpoty.Categorias)
			{
				if (filtro.Id == null)
				{
					var categorias = SpotyRest.GetCategories();
					return this.Ok(categorias);
				}
				else
				{
					var categorias = SpotyRest.GetCategories(filtro.Id);
					return this.Ok(categorias);
				}
			}
			else if (filtro.SpotyFiltro == EnumSpoty.Albums)
			{
				var tracks = SpotyRest.GetAlbuns(filtro.Id);
				return this.Ok(tracks);
			}
			else if (filtro.SpotyFiltro == EnumSpoty.PlayList)
			{
				var playlist = SpotyRest.GetPlaylist(filtro.Id);
				return this.Ok(playlist);
			}
			else
			{
				return this.Ok("Selecione um Filtro (Albums, Categoria ou PlayList)");
			}
		}
	}
}

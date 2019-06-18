using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CashTeste.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CashController : ControllerBase
	{
		private readonly Domain.AppContext _context;

		public CashController(Domain.AppContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<object>> Get()
		{
			return this.Ok(_context.CashValores.ToList());
		}
	}
}

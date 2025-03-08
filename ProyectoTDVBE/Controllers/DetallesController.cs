using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTDVBE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTDVBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DetallesController : ControllerBase
	{
		private readonly Context context;

		// GET: api/<DetallesController>
		public DetallesController(Context context)
		{
			this.context = context;
		}

		[Route("Listado")]
		[HttpGet]
		
		public async Task<ActionResult<IEnumerable<DetalleTrabajador>>> GetTrabajadors()
		{
			return await context.DetalleTrabajadors.ToListAsync();
		}

		// GET api/<DetallesController>/5	

	}
}

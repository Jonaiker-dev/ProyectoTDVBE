using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTDVBE.Models;
using ProyectoTDVBE.Models.DTO;
using ProyectoTDVBE.Utility;

namespace ProyectoTDVBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly Context context;
		private readonly Hashear hashear;

		public LoginController(Context _context,Hashear _hashear )
		{
			context = _context;
			hashear = _hashear;
		}

		//Hacemos un endpoint para registrar un usuario y encriptar la contrase;a
		[HttpPost]
		[Route("Registrarse")]
		public async Task<IActionResult> Registrarse(NuevoUsuarioDTO objeto)
		{
			try
			{
				var modeloUsuario = new Login
				{
					Nombre = objeto.Nombre,
					Correo = objeto.Correo,
					Clave = hashear.EncriptSH256(objeto.Clave)
				};
				await context.Logins.AddAsync(modeloUsuario);
				await context.SaveChangesAsync();
				if (modeloUsuario.IdLogin != 0)
				{
					return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
				}
				else
				{
					return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
				}
			}
			catch(Exception ex)
			{
				return StatusCode(500, new { mensaje = "Ocurrió un error interno."+ex });
			}


		}

		//Aqui se loguea un usuario existente 

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(LoginDTO objeto)
		{
			var usuarioEncontrado = await context.Logins.Where(u => u.Correo == objeto.Correo && u.Clave == hashear.EncriptSH256(objeto.Clave)).FirstOrDefaultAsync();

			if (usuarioEncontrado == null)
			{
				return StatusCode(500, new { isSuccess = false });
			}
			else
			{
				return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
			}
		}


	}
}

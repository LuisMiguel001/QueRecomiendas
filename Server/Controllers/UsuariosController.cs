using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueRecomiendas.Server.DAL;
using QueRecomiendas.Shared.Login;

namespace QueRecomiendas.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuariosController : ControllerBase
	{
		private readonly PeliculasContext _context;

		public UsuariosController(PeliculasContext context)
		{
			_context = context;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(Usuarios user)
		{
			var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == user.Correo);

			if (existingUser != null)
			{
				return BadRequest("El usuario ya existe");
			}

			_context.Usuarios.Add(user);
			await _context.SaveChangesAsync();

			return Ok("Registro exitoso");
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] Usuarios login)
		{
			Sesion sesionDTO = new Sesion();

			if (login.Correo == "luismiguel@gmail.com" && login.Clave == "luis" || login.Correo == "enelalmonte@gmail.com" && login.Clave == "enel")
			{
				sesionDTO.Nombre = "admin";
				sesionDTO.Correo = login.Correo;
				sesionDTO.Rol = "Administrador";
			}
			else
			{
				var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == login.Correo && u.Clave == login.Clave);

				if (existingUser != null)
				{
					sesionDTO.Nombre = "Usuario";
					sesionDTO.Correo = login.Correo;
					sesionDTO.Rol = "Usuarios";
				}
				else
				{
					return NotFound();
				}
			}

			return StatusCode(StatusCodes.Status200OK, sesionDTO);
		}
	}
}

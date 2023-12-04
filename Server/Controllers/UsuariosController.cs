using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using QueRecomiendas.Server.DAL;
using QueRecomiendas.Shared.Login;
using QueRecomiendas.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
		{
			return await _context.Usuarios.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Usuarios>> ObtenerUsuarios(int id)
		{
			if (_context.Usuarios == null)
			{
				return NotFound();
			}
			var usuario = _context.Usuarios
				.Where(l => l.UsuarioId == id)
				.SingleOrDefault();

			if (usuario == null)
			{
				return NotFound("Usuario no encontrado");
			}

			return Ok(usuario);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Usuarios usuarioActualizado)
		{
			var usuario = await _context.Usuarios.FindAsync(id);

			if (usuario == null)
			{
				return NotFound("Usuario no encontrado");
			}

			usuario.Correo = usuarioActualizado.Correo;
			usuario.Clave = usuarioActualizado.Clave;

			await _context.SaveChangesAsync();

			return Ok(usuario);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var usuario = await _context.Usuarios.FindAsync(id);

			if (usuario == null)
			{
				return NotFound("Usuario no encontrado");
			}

			_context.Usuarios.Remove(usuario);
			await _context.SaveChangesAsync();

			return Ok("Usuario eliminado exitosamente");
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(Usuarios user)
		{
			var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == user.Correo);

			if (existingUser != null)
			{
				return BadRequest("El usuario ya existe");
			}

			user.Clave = BCrypt.Net.BCrypt.HashPassword(user.Clave);

			_context.Usuarios.Add(user);
			await _context.SaveChangesAsync();

			return Ok("Registro exitoso");
		}


		[HttpPost("login")]
		public async Task<IActionResult> Login(Usuarios user)
		{
			Sesion sesionDTO = new Sesion();

			if (user.Correo == "luismiguel@aplicada.com" && user.Clave == "luis" || user.Correo == "enelalmonte@aplicada.com" && user.Clave == "enel" || user.Correo == "admin@aplicada.com" && user.Clave == "admin")
			{
				sesionDTO.Nombre = "admin";
				sesionDTO.Correo = user.Correo;
				sesionDTO.Rol = "Administrador";
			}
			else
			{
				var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == user.Correo);

				if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.Clave, existingUser.Clave))
				{
					return BadRequest("Credenciales no válidas");
				}

				var token = GenerateJwtToken(existingUser);
				return Ok(new { Token = token });
			}

			return StatusCode(StatusCodes.Status200OK, sesionDTO);
		}

		private string GenerateJwtToken(Usuarios user)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tu_clave_secreta"));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
			new Claim(JwtRegisteredClaimNames.Sub, user.Correo),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		};

			var token = new JwtSecurityToken(
				issuer: "tu_issuer",
				audience: "tu_audience",
				claims: claims,
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}

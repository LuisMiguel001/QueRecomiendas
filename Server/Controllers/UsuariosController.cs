using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using QueRecomiendas.Server.DAL;
using QueRecomiendas.Shared.Login;
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

			if (user.Correo == "luismiguel@gmail.com" && user.Clave == "luis" || user.Correo == "enelalmonte@gmail.com" && user.Clave == "enel")
			{
				// Usuario autenticado como administrador
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

				// Usuario autenticado como usuario normal
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

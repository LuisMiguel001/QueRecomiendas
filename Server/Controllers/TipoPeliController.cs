using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueRecomiendas.Server.DAL;
using QueRecomiendas.Shared.Models;

namespace QueRecomiendas.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoPeliController : ControllerBase
{
	private readonly PeliculasContext _context;

	public TipoPeliController(PeliculasContext context)
	{
		_context = context;
	}

	public bool Existe(int PeliculaId)
	{
		return (_context.TipoPeliculas?.Any(p => p.TipoPeliculaId == PeliculaId)).GetValueOrDefault();
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<TipoPeliculas>>> Obtener()
	{
		if (_context.TipoPeliculas == null)
		{
			return NotFound();
		}
		else
		{
			return await _context.TipoPeliculas.ToListAsync();
		}
	}

	[HttpGet("{TipoPeliculaId}")]
	public async Task<ActionResult<TipoPeliculas>> ObtenerPeli(int TipoPeliculaId)
	{
		if (_context.TipoPeliculas == null)
		{
			return NotFound();
		}

		var pelicula = await _context.TipoPeliculas
			.Where(l => l.TipoPeliculaId == TipoPeliculaId)
			.FirstOrDefaultAsync();

		if (pelicula == null)
		{
			return NotFound();
		}
		return pelicula;
	}

	[HttpPost]
	public async Task<ActionResult<TipoPeliculas>> PostPeli(TipoPeliculas tipo)
	{
		if (!Existe(tipo.TipoPeliculaId))
		{
			_context.TipoPeliculas.Add(tipo);
		}
		else
		{
			_context.TipoPeliculas.Update(tipo);
		}

		await _context.SaveChangesAsync();
		return Ok(tipo);
	}

	[HttpDelete("{TipoPeliculaId}")]
	public async Task<IActionResult> Eliminar(int TipoPeliculaId)
	{
		if (_context.TipoPeliculas == null)
		{
			return NotFound();
		}

		var pelicula = await _context.TipoPeliculas.FindAsync(TipoPeliculaId);

		if (pelicula == null)
		{
			return NotFound();
		}

		_context.TipoPeliculas.Remove(pelicula);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
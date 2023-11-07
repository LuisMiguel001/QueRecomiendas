using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueRecomiendas.Server.DAL;
using QueRecomiendas.Shared.Models;

namespace QueRecomiendas.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeliculasController : ControllerBase
{
	private readonly PeliculasContext _context;

	public PeliculasController(PeliculasContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Peliculas>>> GetPelicula()
	{
		if (_context.Peliculas == null)
		{
			return NotFound();
		}
		return await _context.Peliculas.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Peliculas>> GetPelicula(int id)
	{
		if (_context.Peliculas == null)
		{
			return NotFound();
		}
		var pelicula = _context.Peliculas
		  .Where(l => l.PeliculaId == id)
		  .Include(o => o.peliculaDetalle)
		  .AsNoTracking()
		  .SingleOrDefault(); ;

		if (pelicula == null)
		{
			return NotFound();
		}

		return pelicula;
	}

	[HttpPost]
	public async Task<ActionResult<Peliculas>> PostPeliculas(Peliculas pelicula)
	{
		if (!Existe(pelicula.PeliculaId))
			_context.Peliculas.Add(pelicula);
		else
			_context.Peliculas.Update(pelicula);

		await _context.SaveChangesAsync();
		return Ok(pelicula);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeletePeliculas(int id)
	{
		if (_context.Peliculas == null)
		{
			return NotFound();
		}

		var pelicula = await _context.Peliculas.FindAsync(id);

		if (pelicula == null)
		{
			return NotFound();
		}

		_context.Peliculas.Remove(pelicula);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool Existe(int id)
	{
		return (_context.Peliculas?.Any(l => l.PeliculaId == id)).GetValueOrDefault();
	}
}
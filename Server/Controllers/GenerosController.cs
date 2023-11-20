using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueRecomiendas.Server.DAL;
using QueRecomiendas.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueRecomiendas.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenerosController : ControllerBase
{
	private readonly PeliculasContext _context;

	public GenerosController(PeliculasContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Generos>>> GetGenerosPelicula()
	{
		return await _context.Generos.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Generos>> GetGeneroPelicula(int id)
	{
		var genero = await _context.Generos.FindAsync(id);

		if (genero == null)
		{
			return NotFound();
		}

		return genero;
	}

	[HttpPost]
	public async Task<ActionResult<Generos>> PostGeneroPelicula(Generos genero)
	{
		if (!GeneroPeliculaExists(genero.GeneroId))
			_context.Generos.Add(genero);
		else
			_context.Generos.Update(genero);

		await _context.SaveChangesAsync();
		return CreatedAtAction("GetGeneroPelicula", new { id = genero.GeneroId }, genero);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutGeneroPelicula(int id, Generos genero)
	{
		if (id != genero.GeneroId)
		{
			return BadRequest();
		}

		_context.Entry(genero).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!GeneroPeliculaExists(id))
			{
				return NotFound();
			}
			else
			{
				throw;
			}
		}

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteGeneroPelicula(int id)
	{
		var genero = await _context.Generos.FindAsync(id);
		if (genero == null)
		{
			return NotFound();
		}

		_context.Generos.Remove(genero);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool GeneroPeliculaExists(int id)
	{
		return _context.Generos.Any(e => e.GeneroId == id);
	}
}
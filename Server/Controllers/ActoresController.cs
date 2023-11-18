using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueRecomiendas.Server.DAL;
using QueRecomiendas.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ActoresController : ControllerBase
{
	private readonly PeliculasContext _context;

	public ActoresController(PeliculasContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Actores>>> GetActores()
	{
		return await _context.Actores.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Actores>> GetActor(int id)
	{
		var actor = await _context.Actores.FindAsync(id);

		if (actor == null)
		{
			return NotFound();
		}

		return actor;
	}

	[HttpPost]
	public async Task<ActionResult<Actores>> PostActor(Actores actor)
	{
		_context.Actores.Add(actor);
		await _context.SaveChangesAsync();

		return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutActor(int id, Actores actor)
	{
		if (id != actor.Id)
		{
			return BadRequest();
		}

		_context.Entry(actor).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!ActorExists(id))
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
	public async Task<IActionResult> DeleteActor(int id)
	{
		var actor = await _context.Actores.FindAsync(id);
		if (actor == null)
		{
			return NotFound();
		}

		_context.Actores.Remove(actor);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool ActorExists(int id)
	{
		return _context.Actores.Any(e => e.Id == id);
	}
}
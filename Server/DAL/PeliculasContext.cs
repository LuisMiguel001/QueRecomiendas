using Microsoft.EntityFrameworkCore;
using QueRecomiendas.Shared.Models;

namespace QueRecomiendas.Server.DAL;

public class PeliculasContext : DbContext
{
	public PeliculasContext(DbContextOptions<PeliculasContext> options)
		: base(options) { }

	public DbSet<Peliculas> Peliculas { get; set; }
	public DbSet<PeliculasDetalle> PeliculaDetalle { get; set; }
}

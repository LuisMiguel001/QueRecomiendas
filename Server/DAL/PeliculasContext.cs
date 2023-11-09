using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QueRecomiendas.Shared.Models;
using System.Collections.Generic;

namespace QueRecomiendas.Server.DAL
{
	public class PeliculasContext : DbContext
	{
		public PeliculasContext(DbContextOptions<PeliculasContext> options)
			: base(options) { }

		public DbSet<Peliculas> Peliculas { get; set; }
		public DbSet<PeliculasDetalle> PeliculaDetalle { get; set; }
		public DbSet<TipoPeliculas> TipoPeliculas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<TipoPeliculas>().HasData(new List<TipoPeliculas>()
		{
			new TipoPeliculas(){TipoPeliculaId=1, Categoria="Acción", Actores="",Disponible = 0 },
			new TipoPeliculas(){TipoPeliculaId=2, Categoria="Terror", Actores="",Disponible = 0},
			new TipoPeliculas(){TipoPeliculaId=3, Categoria="Ciencia ficción", Actores="",Disponible = 0 },
			new TipoPeliculas(){TipoPeliculaId=4, Categoria="Comedia", Actores = "", Disponible = 0 },
			new TipoPeliculas(){TipoPeliculaId=5, Categoria="Aventura y animación", Actores = "", Disponible = 0 },
			new TipoPeliculas(){TipoPeliculaId=6, Categoria="Histórico", Actores = "", Disponible = 0 },
			new TipoPeliculas(){TipoPeliculaId=7, Categoria="Suspenso", Actores = "", Disponible = 0 },
			new TipoPeliculas(){TipoPeliculaId=8, Categoria="Documental", Actores = "", Disponible = 0 }
		});
		}
	}
}

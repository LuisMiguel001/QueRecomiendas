using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QueRecomiendas.Shared.Models;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace QueRecomiendas.Server.DAL
{
    public class PeliculasContext : DbContext
    {
        public PeliculasContext(DbContextOptions<PeliculasContext> options)
            : base(options) { }

        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<PeliculasDetalle> PeliculaDetalle { get; set; }
        public DbSet<TipoPeliculas> TipoPeliculas { get; set; }
        public DbSet<Actores> Actores { get; set; }
        public DbSet<PeliculasActores> PeliculasActores { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<GenerosPeliculas> GenerosPeliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoPeliculas>().HasData(new List<TipoPeliculas>
            {
                new TipoPeliculas { TipoPeliculaId = 1, Categoria = "Acción", Actores = "", Foto = new byte[] { }, Disponible = 0 },
                new TipoPeliculas { TipoPeliculaId = 2, Categoria = "Terror", Actores = "", Foto = new byte[] { }, Disponible = 0 },
                new TipoPeliculas { TipoPeliculaId = 3, Categoria = "Ciencia ficción", Actores = "", Foto = new byte[] { }, Disponible = 0 },
                new TipoPeliculas { TipoPeliculaId = 4, Categoria = "Comedia", Actores = "", Foto = new byte[] { }, Disponible = 0 },
                new TipoPeliculas { TipoPeliculaId = 5, Categoria = "Aventura y animación", Actores = "", Foto = new byte[] { }, Disponible = 0 },
                new TipoPeliculas { TipoPeliculaId = 6, Categoria = "Histórico", Actores = "", Foto = new byte[] { }, Disponible = 0 },
                new TipoPeliculas { TipoPeliculaId = 7, Categoria = "Suspenso", Actores = "", Foto = new byte[] { }, Disponible = 0 },
                new TipoPeliculas { TipoPeliculaId = 8, Categoria = "Documental", Actores = "", Foto = new byte[] { }, Disponible = 0 }
            });

            modelBuilder.Entity<Actores>().HasData(new List<Actores>
            {
	
			});
        }
    }
}
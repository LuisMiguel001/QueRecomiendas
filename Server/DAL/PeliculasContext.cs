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
        public DbSet<Actores> Actores { get; set; }
        public DbSet<PeliculasActores> PeliculasActores { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<GenerosPeliculas> GenerosPeliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actores>().HasData(new List<Actores>
            {
	
			});

            modelBuilder.Entity<Generos>().HasData(new List<Generos>
            {
	
			});
        }
    }
}
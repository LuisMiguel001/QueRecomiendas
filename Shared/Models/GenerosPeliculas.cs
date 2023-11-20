using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueRecomiendas.Shared.Models;

public class GenerosPeliculas
{
	[Key]

	public int GeneroPeliculaId { get; set; }

	public int GeneroId { get; set; }

	public Generos? Genero { get; set; }

	public Peliculas? Pelicula { get; set; }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueRecomiendas.Shared.Models;

public class PeliculasActores
{
	[Key]

	public int ActorPeliId { get; set; }

    public Peliculas Pelicula { get; set; } = null!;

	public int ActorId { get; set; }

	public Actores Actor { get; set; } = null!;
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QueRecomiendas.Shared.Models;

public class PeliculasCaracteristicas
{
	public Peliculas Pelicula { get; set; } = null!;

	public List<PeliculasDetalle> Detalle { get; set; } = new List<PeliculasDetalle>();

	public List<Generos> Generos { get; set; } = new List<Generos>();

	public List<Actores> Actores { get; set; } = new List<Actores>();
}

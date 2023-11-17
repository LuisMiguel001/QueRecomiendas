using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueRecomiendas.Shared.Models;

public class PeliculasDetalle
{
	[Key]
	public int PeliculasDetalleId { get; set; }

	public int PeliculaId { get; set; }

	[Required(ErrorMessage = "Debe Elegir un Genero")]
	public int TipoPeliculaId { get; set; }

    public TipoPeliculas TipoPelicula { get; set; }

    public int Disponible { get; set; }

	[Required(ErrorMessage = "El campo Actores no puede estar vacío")]
	public string? Actores { get; set; }
}

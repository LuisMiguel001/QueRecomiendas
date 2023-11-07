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

	public int DetallePeliculaId { get; set; }

	public int PeliculaId { get; set; }

	public int Disponible { get; set; }

	public string? Actores { get; set; }
}

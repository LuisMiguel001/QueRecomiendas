using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueRecomiendas.Shared.Models;

public class PeliculasDetalle
{
	[Key]
	public int PeliculasDetalleId { get; set; }

	public int PeliculaId { get; set; }

    public int ActorId { get; set; }

	public int GeneroId { get; set; }

	public string? Actores { get; set; }

	public byte[]? Foto { get; set; }	
	
	public string? Categoria { get; set; }

	public string? Descripcion { get; set; }
}

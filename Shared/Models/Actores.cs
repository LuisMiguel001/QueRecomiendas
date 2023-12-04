using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueRecomiendas.Shared.Models;

public class Actores
{
	[Key]

	public int ActorId { get; set; }

	[Required(ErrorMessage = "El Nombre es Requerido")]
	public string Nombre { get; set; } = null!;

	[Required(ErrorMessage = "La Biografia es Requerida")]
	public string? Biografia { get; set; }

	[Required(ErrorMessage = "La Foto es Requerida")]
	public byte[]? Foto { get; set; }

	[Required(ErrorMessage = "La Fecha de Nacimiento es Requerida")]
	public DateTime FechaNacimiento { get; set; } = DateTime.Today;

	public List<PeliculasActores> peliculasActores { get; set; } = new List<PeliculasActores>();

	public override bool Equals(object? obj)
	{
		if (obj is Actores a2)
		{
			return ActorId == a2.ActorId;
		}

		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
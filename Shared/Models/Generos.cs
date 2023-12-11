using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueRecomiendas.Shared.Models;

public class Generos
{
	[Key]

	public int GeneroId { get; set; }

	[Required(ErrorMessage = "El campo {0} es requerido")]
	[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
	public string Categoria { get; set; } = null!;

	[Required(ErrorMessage = "El campo {0} es requerido")]
	public string Descripcion { get; set; } = null!;

	public List<GenerosPeliculas> GenerosPeliculas { get; set; } = new List<GenerosPeliculas>();
}
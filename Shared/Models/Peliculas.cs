﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueRecomiendas.Shared.Models;

public class Peliculas
{
	[Key]

	public int PeliculaId { get; set; }

	[Required(ErrorMessage = "Debe Subir una Imagen")]
	public byte[]? Imagen { get; set; }

	[Required(ErrorMessage = "El Titulo es un Campo Requerido")]
	public string? Titulo { get; set; }

	[Required(ErrorMessage = "La Fecha de Estreno es un Campo Requerido")]
	public DateTime FechaEstreno { get; set; } = DateTime.Today;

	[Required(ErrorMessage = "Debe Agregar un Resumen Sobre la Pelicula")]
	public string? Resena { get; set; }

	public string? Trailer { get; set; }

	public int TipoPeliculaId { get; set; }

    public IEnumerable<TipoPeliculas>? TiposPeliculasList { get; set; }

    [ForeignKey("PeliculaId")]
	public ICollection<PeliculasDetalle> peliculaDetalle { get; set; } = new List<PeliculasDetalle>();
}
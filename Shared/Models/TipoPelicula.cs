using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Shared.Models;

public class TipoPelicula
{
	[Key]

	public int TipoPeliculaId { get; set; }

	[Required(ErrorMessage = "La  categoria es requerido")]
	public string? Categoria { get; set; }

	public int Disponible { get; set; }

	[Required(ErrorMessage = "El el campo Actores no puede estar vacío")]
	public string? Actores { get; set; }
}
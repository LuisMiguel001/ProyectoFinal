using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Server.DAL;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeliController : ControllerBase
{
	private readonly PeliculasContext _context;

	public PeliController(PeliculasContext context)
	{
		_context = context;
	}

	public bool Existe(int PeliculaId)
	{
		return (_context.TipoPelicula?.Any(p => p.TipoPeliculaId == PeliculaId)).GetValueOrDefault();
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<TipoPelicula>>> Obtener()
	{
		if (_context.TipoPelicula == null)
		{
			return NotFound();
		}
		else
		{
			return await _context.TipoPelicula.ToListAsync();
		}
	}

	[HttpGet("{TipoPeliculaId}")]
	public async Task<ActionResult<TipoPelicula>> ObtenerPeli(int TipoPeliculaId)
	{
		if (_context.TipoPelicula == null)
		{
			return NotFound();
		}

		var pelicula = await _context.TipoPelicula
			.Where(l => l.TipoPeliculaId == TipoPeliculaId)
			.FirstOrDefaultAsync();

		if (pelicula == null)
		{
			return NotFound();
		}
		return pelicula;
	}

	[HttpPost]
	public async Task<ActionResult<TipoPelicula>> PostPeli(TipoPelicula tipo)
	{
		if (!Existe(tipo.TipoPeliculaId))
		{
			_context.TipoPelicula.Add(tipo);
		}
		else
		{
			_context.TipoPelicula.Update(tipo);
		}

		await _context.SaveChangesAsync();
		return Ok(tipo);
	}

	[HttpDelete("{TipoPeliculaId}")]
	public async Task<IActionResult> Eliminar(int TipoPeliculaId)
	{
		if (_context.TipoPelicula == null)
		{
			return NotFound();
		}

		var pelicula = await _context.TipoPelicula.FindAsync(TipoPeliculaId);

		if (pelicula == null)
		{
			return NotFound();
		}

		_context.TipoPelicula.Remove(pelicula);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
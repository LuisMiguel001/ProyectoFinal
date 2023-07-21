using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.DAL;

public class LibrosContext : DbContext
{
	public LibrosContext(DbContextOptions<LibrosContext> options)
		:base(options) { }

	public DbSet<Libros> Libros { get; set; }
}


using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Shared.Models;
using System.Data;

namespace ProyectoFinal.Server.DAL;

public class LibrosContext : DbContext
{
	public LibrosContext(DbContextOptions<LibrosContext> options)
		:base(options) { }

	public DbSet<Libros> Libros { get; set; }
	public DbSet<TipoLibro> TipoLibro { get; set; }
	public DbSet<LibrosDetalle> Detalle { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<TipoLibro>().HasData(new List<TipoLibro>()
		{
			new TipoLibro(){TipoId=1, Categoria="Poesía", Autor="",Disponible = 0 },
			new TipoLibro(){TipoId=2, Categoria="Ficción", Autor="",Disponible = 0},
			new TipoLibro(){TipoId=3, Categoria="Autoayuda y desarrollo personal", Autor="",Disponible = 0 },
			new TipoLibro(){TipoId=4, Categoria="Política y sociedad", Autor = "", Disponible = 0 },
			new TipoLibro(){TipoId=5, Categoria="Religión y espiritualidad", Autor = "", Disponible = 0 },
			new TipoLibro(){TipoId=6, Categoria="Historietas y cómics", Autor = "", Disponible = 0 },
			new TipoLibro(){TipoId=7, Categoria="Viajes y aventuras", Autor = "", Disponible = 0 },
			new TipoLibro(){TipoId=8, Categoria="Infantil y juvenil", Autor = "", Disponible = 0 }
		});
	}
}
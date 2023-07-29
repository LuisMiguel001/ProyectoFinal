using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.DAL
{
    public class PeliculasContext : DbContext
    {
        public PeliculasContext(DbContextOptions<PeliculasContext> options)
            : base(options) { }

        public DbSet<Peliculas> Peliculas { get; set; }
		public DbSet<TipoPelicula> TipoPelicula { get; set; }
		public DbSet<PeliculasDetalle> PeliculaDetalle { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<TipoPelicula>().HasData(new List<TipoPelicula>()
		{
			new TipoPelicula(){TipoPeliculaId=1, Categoria="Acción", Actores="",Disponible = 0 },
			new TipoPelicula(){TipoPeliculaId=2, Categoria="Terror", Actores="",Disponible = 0},
			new TipoPelicula(){TipoPeliculaId=3, Categoria="Ciencia ficción", Actores="",Disponible = 0 },
			new TipoPelicula(){TipoPeliculaId=4, Categoria="Comedia", Actores = "", Disponible = 0 },
			new TipoPelicula(){TipoPeliculaId=5, Categoria="Aventura y animación", Actores = "", Disponible = 0 },
			new TipoPelicula(){TipoPeliculaId=6, Categoria="Histórico", Actores = "", Disponible = 0 },
			new TipoPelicula(){TipoPeliculaId=7, Categoria="Suspenso", Actores = "", Disponible = 0 },
			new TipoPelicula(){TipoPeliculaId=8, Categoria="Documental", Actores = "", Disponible = 0 }
		});
		}
	}
}
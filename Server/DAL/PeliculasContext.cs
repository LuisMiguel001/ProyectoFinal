using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.DAL
{
    public class PeliculasContext : DbContext
    {
        public PeliculasContext(DbContextOptions<PeliculasContext> options)
            : base(options) { }

        public DbSet<Peliculas> Peliculas { get; set; }
    }
}

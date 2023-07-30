using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoFinal.Server.Migrations.Peliculas
{
    /// <inheritdoc />
    public partial class Pelicula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imagen = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Puntuacion = table.Column<int>(type: "INTEGER", nullable: false),
                    Resena = table.Column<string>(type: "TEXT", nullable: true),
                    Trailer = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPelicula",
                columns: table => new
                {
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Disponible = table.Column<int>(type: "INTEGER", nullable: false),
                    Actores = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPelicula", x => x.TipoPeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaDetalle",
                columns: table => new
                {
                    DetallePeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponible = table.Column<int>(type: "INTEGER", nullable: false),
                    Actores = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaDetalle", x => x.DetallePeliculaId);
                    table.ForeignKey(
                        name: "FK_PeliculaDetalle_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoPelicula",
                columns: new[] { "TipoPeliculaId", "Actores", "Categoria", "Disponible" },
                values: new object[,]
                {
                    { 1, "", "Acción", 0 },
                    { 2, "", "Terror", 0 },
                    { 3, "", "Ciencia ficción", 0 },
                    { 4, "", "Comedia", 0 },
                    { 5, "", "Aventura y animación", 0 },
                    { 6, "", "Histórico", 0 },
                    { 7, "", "Suspenso", 0 },
                    { 8, "", "Documental", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaDetalle_PeliculaId",
                table: "PeliculaDetalle",
                column: "PeliculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaDetalle");

            migrationBuilder.DropTable(
                name: "TipoPelicula");

            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}

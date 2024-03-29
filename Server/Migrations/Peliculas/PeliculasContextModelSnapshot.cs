﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal.Server.DAL;

#nullable disable

namespace ProyectoFinal.Server.Migrations.Peliculas
{
    [DbContext(typeof(PeliculasContext))]
    partial class PeliculasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("ProyectoFinal.Shared.Models.Peliculas", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("BLOB");

                    b.Property<int>("Puntuacion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resena")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoPeliculaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Trailer")
                        .HasColumnType("TEXT");

                    b.HasKey("PeliculaId");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.PeliculasDetalle", b =>
                {
                    b.Property<int>("DetallePeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Actores")
                        .HasColumnType("TEXT");

                    b.Property<int>("Disponible")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoPeliculaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetallePeliculaId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("PeliculaDetalle");
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.TipoPelicula", b =>
                {
                    b.Property<int>("TipoPeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Actores")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoPeliculaId");

                    b.ToTable("TipoPelicula");

                    b.HasData(
                        new
                        {
                            TipoPeliculaId = 1,
                            Actores = "",
                            Categoria = "Acción",
                            Disponible = 0
                        },
                        new
                        {
                            TipoPeliculaId = 2,
                            Actores = "",
                            Categoria = "Terror",
                            Disponible = 0
                        },
                        new
                        {
                            TipoPeliculaId = 3,
                            Actores = "",
                            Categoria = "Ciencia ficción",
                            Disponible = 0
                        },
                        new
                        {
                            TipoPeliculaId = 4,
                            Actores = "",
                            Categoria = "Comedia",
                            Disponible = 0
                        },
                        new
                        {
                            TipoPeliculaId = 5,
                            Actores = "",
                            Categoria = "Aventura y animación",
                            Disponible = 0
                        },
                        new
                        {
                            TipoPeliculaId = 6,
                            Actores = "",
                            Categoria = "Histórico",
                            Disponible = 0
                        },
                        new
                        {
                            TipoPeliculaId = 7,
                            Actores = "",
                            Categoria = "Suspenso",
                            Disponible = 0
                        },
                        new
                        {
                            TipoPeliculaId = 8,
                            Actores = "",
                            Categoria = "Documental",
                            Disponible = 0
                        });
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.PeliculasDetalle", b =>
                {
                    b.HasOne("ProyectoFinal.Shared.Models.Peliculas", null)
                        .WithMany("peliculaDetalle")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.Peliculas", b =>
                {
                    b.Navigation("peliculaDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}

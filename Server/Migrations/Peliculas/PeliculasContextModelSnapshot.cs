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
                    b.Property<int>("PelicualId")
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

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Trailer")
                        .HasColumnType("TEXT");

                    b.HasKey("PelicualId");

                    b.ToTable("Peliculas");
                });
#pragma warning restore 612, 618
        }
    }
}

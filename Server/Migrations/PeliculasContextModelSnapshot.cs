﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QueRecomiendas.Server.DAL;

#nullable disable

namespace QueRecomiendas.Server.Migrations
{
    [DbContext(typeof(PeliculasContext))]
    partial class PeliculasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("QueRecomiendas.Shared.Models.Peliculas", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Imagen")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Resena")
                        .IsRequired()
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

            modelBuilder.Entity("QueRecomiendas.Shared.Models.PeliculasDetalle", b =>
                {
                    b.Property<int>("PeliculasDetalleId")
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

                    b.HasKey("PeliculasDetalleId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("PeliculaDetalle");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.TipoPeliculas", b =>
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

                    b.ToTable("TipoPeliculas");

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

            modelBuilder.Entity("QueRecomiendas.Shared.Models.PeliculasDetalle", b =>
                {
                    b.HasOne("QueRecomiendas.Shared.Models.Peliculas", null)
                        .WithMany("peliculaDetalle")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.Peliculas", b =>
                {
                    b.Navigation("peliculaDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}

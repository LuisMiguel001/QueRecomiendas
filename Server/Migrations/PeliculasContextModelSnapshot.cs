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

            modelBuilder.Entity("QueRecomiendas.Shared.Models.Actores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Actores");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.Generos", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.GenerosPeliculas", b =>
                {
                    b.Property<int>("GeneroPeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GeneroId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PeliculaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GeneroPeliculaId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("GenerosPeliculas");
                });

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

            modelBuilder.Entity("QueRecomiendas.Shared.Models.PeliculasActores", b =>
                {
                    b.Property<int>("ActorPeliId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActorPeliId");

                    b.HasIndex("ActorId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("PeliculasActores");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.PeliculasDetalle", b =>
                {
                    b.Property<int>("PeliculasDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Actores")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Disponible")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("BLOB");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoPeliculaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PeliculasDetalleId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("TipoPeliculaId");

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

                    b.Property<byte[]>("Foto")
                        .HasColumnType("BLOB");

                    b.Property<int?>("PeliculasPeliculaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoPeliculaId");

                    b.HasIndex("PeliculasPeliculaId");

                    b.ToTable("TipoPeliculas");

                    b.HasData(
                        new
                        {
                            TipoPeliculaId = 1,
                            Actores = "",
                            Categoria = "Acción",
                            Disponible = 0,
                            Foto = new byte[0]
                        },
                        new
                        {
                            TipoPeliculaId = 2,
                            Actores = "",
                            Categoria = "Terror",
                            Disponible = 0,
                            Foto = new byte[0]
                        },
                        new
                        {
                            TipoPeliculaId = 3,
                            Actores = "",
                            Categoria = "Ciencia ficción",
                            Disponible = 0,
                            Foto = new byte[0]
                        },
                        new
                        {
                            TipoPeliculaId = 4,
                            Actores = "",
                            Categoria = "Comedia",
                            Disponible = 0,
                            Foto = new byte[0]
                        },
                        new
                        {
                            TipoPeliculaId = 5,
                            Actores = "",
                            Categoria = "Aventura y animación",
                            Disponible = 0,
                            Foto = new byte[0]
                        },
                        new
                        {
                            TipoPeliculaId = 6,
                            Actores = "",
                            Categoria = "Histórico",
                            Disponible = 0,
                            Foto = new byte[0]
                        },
                        new
                        {
                            TipoPeliculaId = 7,
                            Actores = "",
                            Categoria = "Suspenso",
                            Disponible = 0,
                            Foto = new byte[0]
                        },
                        new
                        {
                            TipoPeliculaId = 8,
                            Actores = "",
                            Categoria = "Documental",
                            Disponible = 0,
                            Foto = new byte[0]
                        });
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.GenerosPeliculas", b =>
                {
                    b.HasOne("QueRecomiendas.Shared.Models.Generos", "Genero")
                        .WithMany("GenerosPeliculas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QueRecomiendas.Shared.Models.Peliculas", "Pelicula")
                        .WithMany()
                        .HasForeignKey("PeliculaId");

                    b.Navigation("Genero");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.PeliculasActores", b =>
                {
                    b.HasOne("QueRecomiendas.Shared.Models.Actores", "Actor")
                        .WithMany("peliculasActores")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QueRecomiendas.Shared.Models.Peliculas", "Pelicula")
                        .WithMany("peliActor")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.PeliculasDetalle", b =>
                {
                    b.HasOne("QueRecomiendas.Shared.Models.Peliculas", null)
                        .WithMany("peliculaDetalle")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QueRecomiendas.Shared.Models.TipoPeliculas", "TipoPelicula")
                        .WithMany()
                        .HasForeignKey("TipoPeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPelicula");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.TipoPeliculas", b =>
                {
                    b.HasOne("QueRecomiendas.Shared.Models.Peliculas", null)
                        .WithMany("TiposPeliculasList")
                        .HasForeignKey("PeliculasPeliculaId");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.Actores", b =>
                {
                    b.Navigation("peliculasActores");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.Generos", b =>
                {
                    b.Navigation("GenerosPeliculas");
                });

            modelBuilder.Entity("QueRecomiendas.Shared.Models.Peliculas", b =>
                {
                    b.Navigation("TiposPeliculasList");

                    b.Navigation("peliActor");

                    b.Navigation("peliculaDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}

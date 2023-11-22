using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueRecomiendas.Server.Migrations
{
    /// <inheritdoc />
    public partial class QueRecomiendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actores",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Biografia = table.Column<string>(type: "TEXT", nullable: false),
                    Foto = table.Column<byte[]>(type: "BLOB", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imagen = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Resena = table.Column<string>(type: "TEXT", nullable: false),
                    Trailer = table.Column<string>(type: "TEXT", nullable: true),
                    GeneroId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "GenerosPeliculas",
                columns: table => new
                {
                    GeneroPeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneroId = table.Column<int>(type: "INTEGER", nullable: false),
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerosPeliculas", x => x.GeneroPeliculaId);
                    table.ForeignKey(
                        name: "FK_GenerosPeliculas_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenerosPeliculas_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId");
                });

            migrationBuilder.CreateTable(
                name: "PeliculaDetalle",
                columns: table => new
                {
                    PeliculasDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActorId = table.Column<int>(type: "INTEGER", nullable: false),
                    GeneroId = table.Column<int>(type: "INTEGER", nullable: false),
                    Actores = table.Column<string>(type: "TEXT", nullable: true),
                    Foto = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    PeliculasPeliculaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaDetalle", x => x.PeliculasDetalleId);
                    table.ForeignKey(
                        name: "FK_PeliculaDetalle_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaDetalle_Peliculas_PeliculasPeliculaId",
                        column: x => x.PeliculasPeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId");
                });

            migrationBuilder.CreateTable(
                name: "PeliculasActores",
                columns: table => new
                {
                    ActorPeliId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasActores", x => x.ActorPeliId);
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Actores_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actores",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenerosPeliculas_GeneroId",
                table: "GenerosPeliculas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_GenerosPeliculas_PeliculaId",
                table: "GenerosPeliculas",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaDetalle_PeliculaId",
                table: "PeliculaDetalle",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaDetalle_PeliculasPeliculaId",
                table: "PeliculaDetalle",
                column: "PeliculasPeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_ActorId",
                table: "PeliculasActores",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_PeliculaId",
                table: "PeliculasActores",
                column: "PeliculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenerosPeliculas");

            migrationBuilder.DropTable(
                name: "PeliculaDetalle");

            migrationBuilder.DropTable(
                name: "PeliculasActores");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}

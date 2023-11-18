using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Biografia = table.Column<string>(type: "TEXT", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores", x => x.Id);
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
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoPeliculas",
                columns: table => new
                {
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Disponible = table.Column<int>(type: "INTEGER", nullable: false),
                    Actores = table.Column<string>(type: "TEXT", nullable: false),
                    PeliculasPeliculaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPeliculas", x => x.TipoPeliculaId);
                    table.ForeignKey(
                        name: "FK_TipoPeliculas_Peliculas_PeliculasPeliculaId",
                        column: x => x.PeliculasPeliculaId,
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
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponible = table.Column<int>(type: "INTEGER", nullable: false),
                    Actores = table.Column<string>(type: "TEXT", nullable: false)
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
                        name: "FK_PeliculaDetalle_TipoPeliculas_TipoPeliculaId",
                        column: x => x.TipoPeliculaId,
                        principalTable: "TipoPeliculas",
                        principalColumn: "TipoPeliculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoPeliculas",
                columns: new[] { "TipoPeliculaId", "Actores", "Categoria", "Disponible", "PeliculasPeliculaId" },
                values: new object[,]
                {
                    { 1, "", "Acción", 0, null },
                    { 2, "", "Terror", 0, null },
                    { 3, "", "Ciencia ficción", 0, null },
                    { 4, "", "Comedia", 0, null },
                    { 5, "", "Aventura y animación", 0, null },
                    { 6, "", "Histórico", 0, null },
                    { 7, "", "Suspenso", 0, null },
                    { 8, "", "Documental", 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaDetalle_PeliculaId",
                table: "PeliculaDetalle",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaDetalle_TipoPeliculaId",
                table: "PeliculaDetalle",
                column: "TipoPeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_ActorId",
                table: "PeliculasActores",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_PeliculaId",
                table: "PeliculasActores",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPeliculas_PeliculasPeliculaId",
                table: "TipoPeliculas",
                column: "PeliculasPeliculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaDetalle");

            migrationBuilder.DropTable(
                name: "PeliculasActores");

            migrationBuilder.DropTable(
                name: "TipoPeliculas");

            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}

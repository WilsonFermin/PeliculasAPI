﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    public partial class Datos_Prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actores",
                columns: new[] { "Id", "FechaNacimiento", "Foto", "Nombre" },
                values: new object[,]
                {
                    { 5, new DateTime(1962, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jim Carrey" },
                    { 6, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert Downey Jr." },
                    { 7, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chris Evans" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 4, "Aventura" },
                    { 5, "Animación" },
                    { 6, "Suspenso" },
                    { 7, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Id", "EnCines", "FechaEstreno", "Poster", "Titulo" },
                values: new object[,]
                {
                    { 4, true, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Avengers: Endgame" },
                    { 5, false, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Avengers: Infinity Wars" },
                    { 6, false, new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sonic the Hedgehog" },
                    { 7, false, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emma" },
                    { 8, false, new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Wonder Woman 1984" }
                });

            migrationBuilder.InsertData(
                table: "PeliculasActores",
                columns: new[] { "ActorID", "PeliculaID", "Orden", "Personaje" },
                values: new object[,]
                {
                    { 5, 6, 1, "Dr. Ivo Robotnik" },
                    { 6, 4, 1, "Tony Stark" },
                    { 6, 5, 1, "Tony Stark" },
                    { 7, 4, 2, "Steve Rogers" },
                    { 7, 5, 2, "Steve Rogers" }
                });

            migrationBuilder.InsertData(
                table: "PeliculasGeneros",
                columns: new[] { "GeneroID", "PeliculaID" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 8 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 7 },
                    { 6, 8 },
                    { 7, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorID", "PeliculaID" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorID", "PeliculaID" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorID", "PeliculaID" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorID", "PeliculaID" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorID", "PeliculaID" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "GeneroID", "PeliculaID" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}

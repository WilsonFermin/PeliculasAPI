using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using PeliculasAPI.Entidades;
using System.Security.Claims;

namespace PeliculasAPI
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
                //Api fluente
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculasActores>()
                .HasKey(x => new { x.ActorID, x.PeliculaID });

            modelBuilder.Entity<PeliculasGeneros>()
                .HasKey(x => new { x.GeneroID, x.PeliculaID });

            modelBuilder.Entity<PeliculasSalasDeCine>()
                .HasKey( x => new {x.PeliculaId, x.SalaDeCineId});

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var aventura = new Genero() { Id = 4, Nombre = "Aventura" };
            var animation = new Genero() { Id = 5, Nombre = "Animación" };
            var suspenso = new Genero() { Id = 6, Nombre = "Suspenso" };
            var romance = new Genero() { Id = 7, Nombre = "Romance" };

            modelBuilder.Entity<Genero>()
                .HasData(new List<Genero>
                {
                    aventura, animation, suspenso, romance
                });

            var jimCarrey = new Actor() { Id = 5, Nombre = "Jim Carrey", FechaNacimiento = new DateTime(1962, 01, 17) };
            var robertDowney = new Actor() { Id = 6, Nombre = "Robert Downey Jr.", FechaNacimiento = new DateTime(1965, 4, 4) };
            var chrisEvans = new Actor() { Id = 7, Nombre = "Chris Evans", FechaNacimiento = new DateTime(1981, 06, 13) };

            modelBuilder.Entity<Actor>()
                .HasData(new List<Actor>
                {
                    jimCarrey, robertDowney, chrisEvans
                });

            var endgame = new Pelicula()
            {
                Id = 4,
                Titulo = "Avengers: Endgame",
                EnCines = true,
                FechaEstreno = new DateTime(2019, 04, 26)
            };

            var iw = new Pelicula()
            {
                Id = 5,
                Titulo = "Avengers: Infinity Wars",
                EnCines = false,
                FechaEstreno = new DateTime(2019, 04, 26)
            };

            var sonic = new Pelicula()
            {
                Id = 6,
                Titulo = "Sonic the Hedgehog",
                EnCines = false,
                FechaEstreno = new DateTime(2022, 06, 28)
            };
            var emma = new Pelicula()
            {
                Id = 7,
                Titulo = "Emma",
                EnCines = false,
                FechaEstreno = new DateTime(2022, 06, 21)
            };
            var wonderwoman = new Pelicula()
            {
                Id = 8,
                Titulo = "Wonder Woman 1984",
                EnCines = false,
                FechaEstreno = new DateTime(2022, 11, 14)
            };

            modelBuilder.Entity<Pelicula>()
                .HasData(new List<Pelicula>
                {
                    endgame, iw, sonic, emma, wonderwoman
                });

            modelBuilder.Entity<PeliculasGeneros>().HasData(
                new List<PeliculasGeneros>()
                {
                    new PeliculasGeneros(){PeliculaID = endgame.Id, GeneroID = suspenso.Id},
                    new PeliculasGeneros(){PeliculaID = endgame.Id, GeneroID = aventura.Id},
                    new PeliculasGeneros(){PeliculaID = iw.Id, GeneroID = suspenso.Id},
                    new PeliculasGeneros(){PeliculaID = iw.Id, GeneroID = aventura.Id},
                    new PeliculasGeneros(){PeliculaID = sonic.Id, GeneroID = aventura.Id},
                    new PeliculasGeneros(){PeliculaID = emma.Id, GeneroID = suspenso.Id},
                    new PeliculasGeneros(){PeliculaID = emma.Id, GeneroID = romance.Id},
                    new PeliculasGeneros(){PeliculaID = wonderwoman.Id, GeneroID = suspenso.Id},
                    new PeliculasGeneros(){PeliculaID = wonderwoman.Id, GeneroID = aventura.Id},
                });

            modelBuilder.Entity<PeliculasActores>().HasData(
                new List<PeliculasActores>()
                {
                    new PeliculasActores(){PeliculaID = endgame.Id, ActorID = robertDowney.Id, Personaje = "Tony Stark", Orden = 1},
                    new PeliculasActores(){PeliculaID = endgame.Id, ActorID = chrisEvans.Id, Personaje = "Steve Rogers", Orden = 2},
                    new PeliculasActores(){PeliculaID = iw.Id, ActorID = robertDowney.Id, Personaje = "Tony Stark", Orden = 1},
                    new PeliculasActores(){PeliculaID = iw.Id, ActorID = chrisEvans.Id, Personaje = "Steve Rogers", Orden = 2},
                    new PeliculasActores(){PeliculaID = sonic.Id, ActorID = jimCarrey.Id, Personaje = "Dr. Ivo Robotnik", Orden = 1}
                });

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var sambil = new SalaDeCine() 
            { 
                Id = 4, 
                Nombre = "Sambil", 
                Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.9118804 ,18.482614)) 
            };

            var megaCentro = new SalaDeCine() 
            { 
                Id = 5, 
                Nombre = "Megacentro", 
                Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.856427, 18.506934)) 
            };

            var villageEastCinema = new SalaDeCine()
            {
                Id = 6,
                Nombre = "Villa East Cinema",
                Ubicacion = geometryFactory.CreatePoint(new Coordinate(-73.986227, 50.730898))
            };

            modelBuilder.Entity<SalaDeCine>()
                .HasData(new List<SalaDeCine>()
                { 
                    sambil, megaCentro, villageEastCinema 
                });

            //Creando un usuario de prueba

            var rolAdminId = "0e079d78-cea9-4724-bf6d-314168bb42ac";
            var usuarioAdminId = "7a37f0b3-3648-42a3-91b1-9b9d94f60924";

            var rolAdmin = new IdentityRole()
            {
                Id = rolAdminId,
                Name = "Admin",
                NormalizedName = "Admin"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();

            var username = "wilson@hotmail.com";

            var usuarioAdmin = new IdentityUser()
            {
                Id = usuarioAdminId,
                UserName = username,
                NormalizedUserName = username,
                Email = username,
                NormalizedEmail = username,
                PasswordHash = passwordHasher.HashPassword(null, "Aa123456!")
            };

            ////Agregamos el usuario
            //modelBuilder.Entity<IdentityUser>()
            //    .HasData(usuarioAdmin);

            ////Agregamos el rol
            //modelBuilder.Entity<IdentityRole>()
            //    .HasData(rolAdmin);

            ////Agregamos el rol al usuario
            //modelBuilder.Entity<IdentityUserClaim<string>>()
            //    .HasData(new IdentityUserClaim<string>()
            //    {
            //        Id = 1,
            //        ClaimType = ClaimTypes.Role,
            //        UserId = usuarioAdminId,
            //        ClaimValue = "Admin"
            //    });
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculasActores> PeliculasActores { get; set; }
        public DbSet<PeliculasGeneros> PeliculasGeneros { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<PeliculasSalasDeCine> PeliculasSalasDeCines { get; set; }

    }
}

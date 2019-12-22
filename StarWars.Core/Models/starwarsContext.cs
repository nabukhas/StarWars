using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StarWars.Core.Models
{
    public partial class StarwarsContext : DbContext
    {
        public StarwarsContext()
        {
        }

        public StarwarsContext(DbContextOptions<StarwarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<FilmsCharacters> FilmsCharacters { get; set; }
        public virtual DbSet<FilmsPlanets> FilmsPlanets { get; set; }
        public virtual DbSet<FilmsSpecies> FilmsSpecies { get; set; }
        public virtual DbSet<FilmsStarships> FilmsStarships { get; set; }
        public virtual DbSet<FilmsVehicles> FilmsVehicles { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Planets> Planets { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<SpeciesPeople> SpeciesPeople { get; set; }
        public virtual DbSet<Starships> Starships { get; set; }
        public virtual DbSet<StarshipsPilots> StarshipsPilots { get; set; }
        public virtual DbSet<Transports> Transports { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<VehiclesPilots> VehiclesPilots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=candidate-test.caqylurhpyhw.eu-west-1.rds.amazonaws.com;Initial Catalog=star-wars;Persist Security Info=True;User ID=candidate;Password=candidate;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Films>(entity =>
            {
                entity.ToTable("films");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Director).HasColumnName("director");

                entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpisodeId).HasColumnName("episode_id");

                entity.Property(e => e.OpeningCrawl).HasColumnName("opening_crawl");

                entity.Property(e => e.Producer).HasColumnName("producer");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<FilmsCharacters>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.PeopleId })
                    .HasName("PK__films_ch__DDB37E288E5B4C92");

                entity.ToTable("films_characters");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmsCharacters)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_characters_films_0");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.FilmsCharacters)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_characters_films_1");
            });

            modelBuilder.Entity<FilmsPlanets>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.PlanetId })
                    .HasName("PK__films_pl__54EAE2D1A535F89D");

                entity.ToTable("films_planets");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.PlanetId).HasColumnName("planet_id");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmsPlanets)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_films_planets_films_0");

                entity.HasOne(d => d.Planet)
                    .WithMany(p => p.FilmsPlanets)
                    .HasForeignKey(d => d.PlanetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_films_planets_films_1");
            });

            modelBuilder.Entity<FilmsSpecies>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.SpeciesId })
                    .HasName("PK__films_sp__0FB4B8F5E703A161");

                entity.ToTable("films_species");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmsSpecies)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_films_species_films_0");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.FilmsSpecies)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_films_species_films_1");
            });

            modelBuilder.Entity<FilmsStarships>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.StarshipId })
                    .HasName("PK__films_st__1AE7DBE4A2027E09");

                entity.ToTable("films_starships");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.StarshipId).HasColumnName("starship_id");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmsStarships)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_films_starships_films_0");

                entity.HasOne(d => d.Starship)
                    .WithMany(p => p.FilmsStarships)
                    .HasForeignKey(d => d.StarshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_films_starships_films_1");
            });

            modelBuilder.Entity<FilmsVehicles>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.VehicleId })
                    .HasName("PK__films_ve__3BBE231524FC4F69");

                entity.ToTable("films_vehicles");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmsVehicles)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_films_vehicles_films_0");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.FilmsVehicles)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_films_vehicles_films_1");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthYear).HasColumnName("birth_year");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");

                entity.Property(e => e.EyeColor).HasColumnName("eye_color");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.HairColor).HasColumnName("hair_color");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Homeworld).HasColumnName("homeworld");

                entity.Property(e => e.Mass).HasColumnName("mass");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.SkinColor).HasColumnName("skin_color");
            });

            modelBuilder.Entity<Planets>(entity =>
            {
                entity.ToTable("planets");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Climate).HasColumnName("climate");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Diameter).HasColumnName("diameter");

                entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gravity).HasColumnName("gravity");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OrbitalPeriod).HasColumnName("orbital_period");

                entity.Property(e => e.Population).HasColumnName("population");

                entity.Property(e => e.RotationPeriod).HasColumnName("rotation_period");

                entity.Property(e => e.SurfaceWater).HasColumnName("surface_water");

                entity.Property(e => e.Terrain).HasColumnName("terrain");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.ToTable("species");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AverageHeight).HasColumnName("average_height");

                entity.Property(e => e.AverageLifespan).HasColumnName("average_lifespan");

                entity.Property(e => e.Classification).HasColumnName("classification");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Designation).HasColumnName("designation");

                entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");

                entity.Property(e => e.EyeColors).HasColumnName("eye_colors");

                entity.Property(e => e.HairColors).HasColumnName("hair_colors");

                entity.Property(e => e.Homeworld).HasColumnName("homeworld");

                entity.Property(e => e.Language).HasColumnName("language");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.SkinColors).HasColumnName("skin_colors");
            });

            modelBuilder.Entity<SpeciesPeople>(entity =>
            {
                entity.HasKey(e => new { e.SpeciesId, e.PeopleId })
                    .HasName("PK__species___5B19DF43D3DEF7E3");

                entity.ToTable("species_people");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.SpeciesPeople)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_species_people_species_1");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.SpeciesPeople)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_species_people_species_0");
            });

            modelBuilder.Entity<Starships>(entity =>
            {
                entity.ToTable("starships");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.HyperdriveRating).HasColumnName("hyperdrive_rating");

                entity.Property(e => e.Mglt).HasColumnName("MGLT");

                entity.Property(e => e.StarshipClass).HasColumnName("starship_class");
            });

            modelBuilder.Entity<StarshipsPilots>(entity =>
            {
                entity.HasKey(e => new { e.StarshipId, e.PeopleId })
                    .HasName("PK__starship__0E2FEE52C3341B64");

                entity.ToTable("starships_pilots");

                entity.Property(e => e.StarshipId).HasColumnName("starship_id");

                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.StarshipsPilots)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_starships_pilots_starships_1");

                entity.HasOne(d => d.Starship)
                    .WithMany(p => p.StarshipsPilots)
                    .HasForeignKey(d => d.StarshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_starships_pilots_starships_0");
            });

            modelBuilder.Entity<Transports>(entity =>
            {
                entity.ToTable("transports");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CargoCapacity).HasColumnName("cargo_capacity");

                entity.Property(e => e.Consumables).HasColumnName("consumables");

                entity.Property(e => e.CostInCredits).HasColumnName("cost_in_credits");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Crew).HasColumnName("crew");

                entity.Property(e => e.Edited)
                    .HasColumnName("edited")
                    .HasColumnType("datetime");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");

                entity.Property(e => e.MaxAtmospheringSpeed).HasColumnName("max_atmosphering_speed");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Passengers).HasColumnName("passengers");
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.ToTable("vehicles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.VehicleClass).HasColumnName("vehicle_class");
            });

            modelBuilder.Entity<VehiclesPilots>(entity =>
            {
                entity.HasKey(e => new { e.VehicleId, e.PeopleId })
                    .HasName("PK__vehicles__1BB06140F1814544");

                entity.ToTable("vehicles_pilots");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.VehiclesPilots)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_veehicles_pilots_vehicles_1");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehiclesPilots)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s3t_veehicles_pilots_vehicles_0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

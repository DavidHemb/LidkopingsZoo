﻿using LidkopingsZoo.Models;
using LidkopingsZoo.Models.Elements;
using LidkopingsZoo.Models.Animals.LandAnimals;
using LidkopingsZoo.Models.Animals.WaterAnimals;
using LidkopingsZoo.Models.Animals.AirAnimals;
using LidkopingsZoo.Models.Visitation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics.Contracts;

namespace LidkopingsZoo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Guide> Guides { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
               .HasDiscriminator<bool>("HasHabitat")
               .HasValue<Habitat>(true);

            modelBuilder.Entity<Habitat>()
                .HasDiscriminator<int>("HabitatId")
                .HasValue<Air>(1)
                .HasValue<Land>(2)
                .HasValue<Water>(3);

            modelBuilder.Entity<Air>()
                .HasDiscriminator<string>("AirAnimal")?
                .HasValue<Dragon>("Dragon")
                .HasValue<Goose>("Goose")
                .HasValue<Griffin>("Griffin");

            modelBuilder.Entity<Land>()
                .HasDiscriminator<string>("LandAnimal")?
                .HasValue<Cow>("Cow")
                .HasValue<Giganotosaurus>("Giganotosaurus")
                .HasValue<SantaClaus>("SantaClaus");

            modelBuilder.Entity<Water>()
                .HasDiscriminator<string>("WaterAnimal")?
                .HasValue<Kraken>("Kraken")
                .HasValue<Orca>("Orca")
                .HasValue<Penguin>("Penguin");

            //modelBuilder.Entity<Habitat>(x => x.HasBaseType<Animal>());

            //modelBuilder.Entity<Air>(x => x.HasBaseType<Habitat>());
            //modelBuilder.Entity<Land>(x => x.HasBaseType<Habitat>());
            //modelBuilder.Entity<Water>(x => x.HasBaseType<Habitat>());

            //modelBuilder.Entity<Dragon>(x => x.HasBaseType<Air>());
            //modelBuilder.Entity<Goose>(x => x.HasBaseType<Air>());
            //modelBuilder.Entity<Griffin>(x => x.HasBaseType<Air>());

            //modelBuilder.Entity<Cow>(x => x.HasBaseType<Land>());
            //modelBuilder.Entity<Giganotosaurus>(x => x.HasBaseType<Land>());
            //modelBuilder.Entity<SantaClaus>(x => x.HasBaseType<Land>());

            //modelBuilder.Entity<Kraken>(x => x.HasBaseType<Water>());
            //modelBuilder.Entity<Orca>(x => x.HasBaseType<Water>());
            //modelBuilder.Entity<Penguin>(x => x.HasBaseType<Water>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
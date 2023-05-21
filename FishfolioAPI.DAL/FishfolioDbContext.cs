using FishfolioAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishfolioAPI.DAL
{
    public class FishfolioDbContext : DbContext
    {
        public FishfolioDbContext(DbContextOptions<FishfolioDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<FishFamily> FishFamilies { get; set; } 

        public DbSet<FishFamilyCompatibility> FishFamilyCompatibility { get; set; }
        public DbSet<FishFamilyIncompatibility> FishFamilyIncompatibility { get; set; }

        public DbSet<WaterType> WaterTypes { get; set; }

        public DbSet<Fish> Fish { get; set; }

        public DbSet<FavoriteFish> FavoriteFish { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FishFamilyConfiguration());
            modelBuilder.ApplyConfiguration(new FishFamilyConfiguration2());
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "admin", Password = "admin1", Email = "anakonjetic@gmail.com", UserType = 0 });
            modelBuilder.Entity<Habitat>().HasData(new Habitat { Id = 1, Name = "Tropical waters of South America" });
            modelBuilder.Entity<FishFamily>().HasData(new FishFamily { Id = 1, Name = "Tetra" });
            modelBuilder.Entity<FishFamily>().HasData(new FishFamily { Id = 2, Name = "Rasbora" });
            modelBuilder.Entity<FishFamily>().HasData(new FishFamily { Id = 3, Name = "Gourami" });
            modelBuilder.Entity<FishFamily>().HasData(new FishFamily { Id = 4, Name = "Barb" });
            modelBuilder.Entity<FishFamily>().HasData(new FishFamily { Id = 5, Name = "Cichlid" });
            modelBuilder.Entity<FishFamily>().HasData(new FishFamily { Id = 6, Name = "Betta" });
            modelBuilder.Entity<WaterType>().HasData(new WaterType { Id = 1, Type = "Salty" });
            modelBuilder.Entity<WaterType>().HasData(new WaterType { Id = 2, Type = "Fresh" });
            modelBuilder.Entity<FishFamilyCompatibility>().HasData(new FishFamilyCompatibility { ParentId = 1, CompatibilityId = 2 });
            modelBuilder.Entity<FishFamilyCompatibility>().HasData(new FishFamilyCompatibility { ParentId = 1, CompatibilityId = 3 });
            modelBuilder.Entity<FishFamilyCompatibility>().HasData(new FishFamilyCompatibility { ParentId = 1, CompatibilityId = 4 });
            modelBuilder.Entity<FishFamilyIncompatibility>().HasData(new FishFamilyIncompatibility { ParentId = 1, CompatibilityId = 5 });
            modelBuilder.Entity<FishFamilyIncompatibility>().HasData(new FishFamilyIncompatibility { ParentId = 1, CompatibilityId = 6 });

        }

    }
}
using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.Data.EntitiesConfiguration;
using HW4._4_EntityFreamwork.DbModels;
using Microsoft.EntityFrameworkCore;

namespace HW4._4_EntityFreamwork.Data
{
    public sealed class AnimalsApplicationContext : DbContext
    {
        public AnimalsApplicationContext(DbContextOptions<AnimalsApplicationContext> animals) : base(animals)
        {
        }

        public DbSet<PetEntity> Pets { get; set; } = null!;
        public DbSet<CategoryEntity> Categoties { get; set; } = null!;
        public DbSet<BreedEntity> Breeds { get; set; } = null!;
        public DbSet<LocationEntity> Locations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PetEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BreedEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
            modelBuilder.UseHiLo();
        }

    }
}

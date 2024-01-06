using HW4._4_EntityFreamwork.DbModels;
using Microsoft.EntityFrameworkCore;

namespace HW4._4_EntityFreamwork
{
    public sealed class AnimalsApplicationContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Category> Categoties { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Location> Locations { get; set; }

        public AnimalsApplicationContext(DbContextOptions<AnimalsApplicationContext> animals) : base(animals)
        {

        }

    }
}

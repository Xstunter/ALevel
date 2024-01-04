namespace HW4._4_EntityFreamwork
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    public sealed class AnimalsApplicationsContextFactory : IDesignTimeDbContextFactory<AnimalsApplicationContext>
    {
        public AnimalsApplicationContext CreateDbContext(string[] args)
        {
            var connectionString =
    "Data Source=DESKTOP-1MPCTDH\\SQLEXPRESS;Initial Catalog=Animals;Integrated Security=True; TrustServerCertificate=True";
            var optionBuilder = new DbContextOptionsBuilder<AnimalsApplicationContext>();
            var options = optionBuilder
                .UseSqlServer(connectionString)
                .Options;
            return new AnimalsApplicationContext(options);
        }
    }
}

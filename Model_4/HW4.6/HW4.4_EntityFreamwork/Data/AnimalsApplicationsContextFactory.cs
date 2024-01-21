namespace HW4._4_EntityFreamwork.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    public sealed class AnimalsApplicationsContextFactory : IDesignTimeDbContextFactory<AnimalsApplicationContext>
    {
        public AnimalsApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnimalsApplicationContext>();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("D:\\C#\\ALevel\\Model_4\\HW4.6\\HW4.4_EntityFreamwork\\config.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            connectionString += "; TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString, opts
                => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new AnimalsApplicationContext(optionsBuilder.Options);
        }
    }
}

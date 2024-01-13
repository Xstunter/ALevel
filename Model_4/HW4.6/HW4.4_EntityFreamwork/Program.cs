using HW4._4_EntityFreamwork;
using HW4._4_EntityFreamwork.Data;
using HW4._4_EntityFreamwork.Repositories;
using HW4._4_EntityFreamwork.Repositories.Abstractions;
using HW4._4_EntityFreamwork.Services;
using HW4._4_EntityFreamwork.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

sealed class Program
{
    public static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        connectionString += "; TrustServerCertificate=True";
        serviceCollection.AddDbContextFactory<AnimalsApplicationContext>(opts
            => opts.UseSqlServer(connectionString));
        serviceCollection.AddScoped<IDbContextWrapper<AnimalsApplicationContext>, DbContextWrapper<AnimalsApplicationContext>>();

        serviceCollection
            .AddLogging(configure => configure.AddConsole())
            .AddTransient<IPetService, PetService>()
            .AddTransient<IPetRepository, PetRepository>()
            .AddTransient<IBreedService, BreedService>()
            .AddTransient<IBreedRepository, BreedRepository>()
            .AddTransient<ILocationService, LocationService>()
            .AddTransient<ILocationRepository, LocationRepository>()
            .AddTransient<ICategoryService, CategoryService>()
            .AddTransient<ICategoryRepository, CategoryRepository>()
            .AddTransient<App>();
    }
    
    public static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("D:\\C#\\ALevel\\Model_4\\HW4.6\\HW4.4_EntityFreamwork\\config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var migrationSection = configuration.GetSection("Migration");
        var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

        if (bool.Parse(isNeedMigration.Value))
        {
            var dbContext = provider.GetService<AnimalsApplicationContext>();
            await dbContext!.Database.MigrateAsync();
        }

        var app = provider.GetService<App>();
        await app!.Start();
    }
}
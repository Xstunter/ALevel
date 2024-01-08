using HW4._4_EntityFreamwork;
using System;
using System.Threading.Tasks;

sealed class Program
{
    public static async Task Main(string[] args)
    {
        await using (AnimalsApplicationContext context  = new AnimalsApplicationsContextFactory().CreateDbContext(Array.Empty<string>()))
        {
            context.Database.EnsureCreated();
        }
    }
}
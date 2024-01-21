using HW3._2_Dictionary;
using HW3._2_Dictionary.Repositories;
using HW3._2_Dictionary.Repositories.Abstracts;
using HW3._2_Dictionary.Services;
using HW3._2_Dictionary.Services.Abstracts;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection()
            .AddTransient<IPhoneService, PhoneService>()
            .AddScoped<IPhoneRepository, PhoneRepository>()
            .AddTransient<App>();

        var provider = serviceCollection.BuildServiceProvider();
        var app = provider.GetService<App>();
        app!.Start();
    }
}

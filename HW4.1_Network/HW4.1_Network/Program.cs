using HW4._1_Network;
using HW4._1_Network.Config;
using HW4._1_Network.Services.Abstracts;
using HW4._1_Network.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

internal sealed class Program
{
    public static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
        serviceCollection
            .AddLogging(configure => configure.AddConsole())
            .AddHttpClient()
            .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<App>();
    }

    public static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("D:\\C#\\HW4.1_Network\\HW4.1_Network\\config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        await app!.Start();
    }
}
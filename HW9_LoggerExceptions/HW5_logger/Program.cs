using HW5_logger;
using HW9_LoggerExceptions.Service;
using HW9_LoggerExceptions.Service.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("D:\\C#\\ALevel\\HW9_LoggerExceptions\\HW5_logger\\config.json")
    .Build();

var serviceCollection = new ServiceCollection();

ConfigureServices(serviceCollection);
void ConfigureServices(ServiceCollection serviceCollection)
{
    serviceCollection
        .AddScoped<ILogger, Logger>()
        .AddTransient<IActions, Actions>()
        .AddTransient<FileService>()
        .AddTransient<Starter>();
}

serviceCollection.AddSingleton(configuration);


var provider = serviceCollection.BuildServiceProvider();

var start = provider.GetService<Starter>();
start!.Run();


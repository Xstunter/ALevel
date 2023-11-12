using HW8_Salad.Services;
using HW8_Salad.Services.Abstracts;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection()
    .AddTransient<ISaladService, SaladService>()
    .AddTransient<App>();

var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();

app!.AppStart();
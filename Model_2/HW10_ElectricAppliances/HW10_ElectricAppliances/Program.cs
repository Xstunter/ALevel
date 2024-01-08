using HW10_ElectricAppliances;
using HW10_ElectricAppliances.Repositories;
using HW10_ElectricAppliances.Repository.Abstracts;
using HW10_ElectricAppliances.Services;
using HW10_ElectricAppliances.Services.Abstracts;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection()
    .AddTransient<IElectricalService, ElectricalService>()
    .AddScoped<IElectricalRepository, ElectricalRepository>()
    .AddTransient<App>();

var provider = serviceCollection.BuildServiceProvider();
var app =provider.GetService<App>();
app!.AppStart();
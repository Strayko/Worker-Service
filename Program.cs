
using ConsoleApp34;
using ConsoleApp34.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<IItemService, ItemService>();
    })
    .Build();
    
await host.RunAsync();
using ConsoleApp34.Data;

namespace ConsoleApp34;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IItemService _service;

    public Worker(ILogger<Worker> logger, IItemService service)
    {
        _logger = logger;
        _service = service;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Background service is starting....");
        cancellationToken.Register(() => _logger.LogDebug("Background service is stopping...."));

        while (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            foreach (var item in _service.GetItems())
            {
                _logger.LogInformation($"Item {item.Id} - {item.Name} - {item.IsCompleted}");
            }

            await Task.Delay(5000, cancellationToken);
        }
    }
}
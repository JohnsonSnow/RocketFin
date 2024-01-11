using Microsoft.Extensions.Logging;
using Quartz;

namespace Infrastructure.BackgroundJobs;

[DisallowConcurrentExecution]
public class ExternalInvestmentApiCallBackgroundJob : IJob
{
    private readonly ILogger<ExternalInvestmentApiCallBackgroundJob> _logger;

    public ExternalInvestmentApiCallBackgroundJob(ILogger<ExternalInvestmentApiCallBackgroundJob> logger)
    {
        _logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("start logging");

        return Task.CompletedTask;
    }

}

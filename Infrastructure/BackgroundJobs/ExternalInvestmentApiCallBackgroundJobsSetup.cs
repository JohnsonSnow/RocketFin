using Microsoft.Extensions.Options;
using Quartz;

namespace Infrastructure.BackgroundJobs;

public class ExternalInvestmentApiCallBackgroundJobSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var jobKey = JobKey.Create(nameof(ExternalInvestmentApiCallBackgroundJobSetup));

        options.AddJob<ExternalInvestmentApiCallBackgroundJob>(JobBuilder => JobBuilder.WithIdentity(jobKey))
            .AddTrigger(trigger => trigger.ForJob(jobKey).WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(2).RepeatForever()));
    }
}

using Application.Behaviors;
using Application.Features.Investment.Queries.GetStockByInstrumentTickerId;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
            //configuration.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        services.AddResiliencePipeline<string, FinanceApiResponse?>("finance-api-pipeline", pipelineBuilder =>
        {
            pipelineBuilder.AddRetry(new Polly.Retry.RetryStrategyOptions<FinanceApiResponse?>
            {
                MaxRetryAttempts = 3,
                BackoffType = DelayBackoffType.Constant,
                Delay = TimeSpan.Zero,
                ShouldHandle = new PredicateBuilder<FinanceApiResponse?>().Handle<ApplicationException>(),
                OnRetry = retryArguments =>
                {
                    Console.WriteLine($"Current Attemp: {retryArguments.AttemptNumber}, {retryArguments.Outcome}");

                    return ValueTask.CompletedTask;
                }
            }).Build();
        });

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}

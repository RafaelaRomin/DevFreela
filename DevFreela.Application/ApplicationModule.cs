using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Consumers;
using DevFreela.Application.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateProjectCommand>())
            .AddValidators()
            .AddConsumers();
        
        return services;
    }

    public static IServiceCollection AddConsumers(this IServiceCollection services)
    {
        services
            .AddHostedService<PaymentApprovedConsumer>();

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
                .AddFluentValidation(fv => fv
                .RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

        return services;
    }
}
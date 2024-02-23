using System.Text;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.AuthServices;
using DevFreela.Infrastructure.MessageBus;
using DevFreela.Infrastructure.Payments;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DevFreela.API.Extensions;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistense(configuration)
            .AddRepositories()
            .AddUnitOfWork()
            .AddAuthentication(configuration)
            .AddMessageBus()
            .AddServices();

        return services;
    }

    private static IServiceCollection AddPersistense(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DevFreelaDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DevFreelaCs")));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectRepositoy>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }

    private static IServiceCollection AddMessageBus(this IServiceCollection services)
    {
        services.AddScoped<IMessageBusService, MessageBusService>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services
            .AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
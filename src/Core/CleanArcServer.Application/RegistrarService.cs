using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArcServer.Application;

public static class RegistrarService
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(RegistrarService).Assembly);
            cfg.AddOpenBehavior(typeof(Behaviors.ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(Behaviors.PermissionBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(RegistrarService).Assembly);

        return services;
    }
}
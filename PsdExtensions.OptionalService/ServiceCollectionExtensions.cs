using System;
using Microsoft.Extensions.DependencyInjection;

namespace PsdExtensions.OptionalService;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptionalServices(this IServiceCollection services)
    {
        return services.AddTransient(typeof(OptionalService<>));
    }
}

using Abstractions.Services;
using Application.Services;
using MediatR;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureApplication
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ConfigureApplication).GetTypeInfo().Assembly);
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IQueryService, QueryService>();
        }
    }
}
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoList.Application.Aggregates.UserProfiles.Events;
using TodoList.Application.Common;

namespace TodoList.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddHostedService<UserRegisteredEvent>();

            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}

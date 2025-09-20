using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Interfaces;

namespace TodoList.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TodoListDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgresBackendConnection")));

            services.AddScoped<ITodoListDbContext>(provider => provider.GetService<TodoListDbContext>());

            return services;
        }
    }
}

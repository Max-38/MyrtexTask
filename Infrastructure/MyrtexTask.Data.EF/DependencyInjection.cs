using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyrtexTask.Application.Interfaces;

namespace MyrtexTask.Data.EF
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyrtexTaskDb (this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<MyrtexTaskDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Singleton);

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}

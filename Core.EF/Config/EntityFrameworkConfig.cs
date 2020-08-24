using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.EF.Config
{
    public static class EntityFrameworkConfig
    {
        public static void ConfigureEntityFramework(this IServiceCollection services, string dbConnectionString)
        {
            services.AddDbContext<capacitacion>(
                options => options.UseOracle(dbConnectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

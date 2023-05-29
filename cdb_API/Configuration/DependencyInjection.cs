using Application.Interfaces;
using Application.Services.CDB;

namespace cdb_API.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICdbCalculoService, CdbCalculoService>();
        }
    }
}

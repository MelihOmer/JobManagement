using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoPlayerLearn.DataAccess.Context;
using VideoPlayerLearn.DataAccess.UnitOfWork;

namespace VideoPlayerLearn.DataAccess
{
    public static class DataAccessExtension
    {
        public static void AddDataAccessDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("default"));
            });

            services.AddScoped<IUow, Uow>();
        }

    }
}

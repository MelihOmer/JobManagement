using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Concrete;
using VideoPlayerLearn.Business.ValidationRules;

namespace VideoPlayerLearn.Business
{
    public static class BusinessExtension
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining(typeof(AppUserCreateDtoValidator),ServiceLifetime.Transient);

            services.AddScoped<ICustomUserManager, CustomUserManager>();
        }
    }
}

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Concrete;
using VideoPlayerLearn.Business.ValidationRules;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business
{
    public static class BusinessExtension
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IValidator<TodoCreateDto>, TodoCreateValidator>();
            services.AddScoped<IValidator<TodoUpdateDto>, TodoUpdateDtoValidator>();
            services.AddScoped<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddFluentValidationAutoValidation();
            

            services.AddValidatorsFromAssemblyContaining(typeof(AppUserCreateDtoValidator),ServiceLifetime.Transient);

            services.AddScoped<ICustomUserManager, CustomUserManager>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<ITodoStatusService, TodoStatusService>();
            services.AddScoped<ITodoCommentService,TodoCommentsService>();
            services.AddScoped<ITodoFileService,TodoFileService>();
            services.AddScoped<IEducationCategoryService,EducationCategoryService>();
            services.AddScoped<IEducationService,EducationService>();
            services.AddScoped<ITodoViewsUserService,TodoViewsUserService>();
            services.AddScoped<IClientNotificationService, ClientNotificationServicce>();
            services.AddScoped<IStatusMessageService, StatusMessageService>();
        }
    }
}

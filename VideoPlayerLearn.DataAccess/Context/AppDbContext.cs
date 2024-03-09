using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.DataAccess.EntityConfiguration;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoComment> TodoComments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TodoStatus> TodoStatuses { get; set; }
        public DbSet<TodoFile> TodoFiles { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationCategory> EducationCategories { get; set; }
        public DbSet<TodoViewsUser> TodoViewsUsers { get; set; }
       // public DbSet<ClientNotification> ClientNotifications { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TodoConfiguration).Assembly);

            base.OnModelCreating(builder);
        }
    }
}

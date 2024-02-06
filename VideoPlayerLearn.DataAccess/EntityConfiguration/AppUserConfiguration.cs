using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.DataAccess.EntityConfiguration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();
            builder.ToTable("AspNetUsers");

            var adminUser = new AppUser
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                PhoneNumber = "123456789",
                FirstName = "admin",
                LastName = "admin",
                ExtensionNo = "1",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImagePath = "/defaultUser.jpg",
                DepartmentId = 1
            };
            adminUser.PasswordHash = CreatePasswordHash(adminUser, "12345");
            var sistemUser = new AppUser
            {
                Id = 2,
                UserName = "ticketsistem",
                NormalizedUserName = "TICKETSISTEM",
                Email = "ticket@mail.com",
                NormalizedEmail = "TICKET@MAIL.COM",
                PhoneNumber = "123456789",
                FirstName = "Ticket",
                LastName = "Sistem",
                ExtensionNo = "1",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImagePath = "/system.jpg",
                DepartmentId = 1
            };
            sistemUser.PasswordHash = CreatePasswordHash(sistemUser, "12345");
            builder.HasData(adminUser, sistemUser);
        }


        private string CreatePasswordHash(AppUser user,string password)
        {
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.DataAccess.EntityConfiguration
{
    public class AppUserClaimsConfiguration : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(new AppUserClaim
            {
                Id = 1,
                ClaimType = "deparmentId",
                ClaimValue = "1",
                UserId = 1
            },
            new AppUserClaim
            {
                Id = 2,
                ClaimType = "departmentName",
                ClaimValue = "Bilgi İşlem Yazılım",
                UserId = 1
            },
            new AppUserClaim
            {
                Id = 3,
                ClaimType = "userId",
                ClaimValue = "1",
                UserId = 1
            },
            new AppUserClaim
            {
                Id = 4,
                ClaimType = "ImagePath",
                ClaimValue = "/system.jpg",
                UserId = 1
            },
            new AppUserClaim
            {
                Id = 5,
                ClaimType = "UserFirstLastName",
                ClaimValue = "Admin Account",
                UserId = 1
            },
            new AppUserClaim
            {
                Id = 6,
                ClaimType = "deparmentId",
                ClaimValue = "1",
                UserId = 2
            },
            new AppUserClaim
            {
                Id = 7,
                ClaimType = "departmentName",
                ClaimValue = "Bilgi İşlem Yazılım",
                UserId = 2
            },
            new AppUserClaim
            {
                Id = 8,
                ClaimType = "userId",
                ClaimValue = "2",
                UserId = 2
            },
            new AppUserClaim
            {
                Id = 9,
                ClaimType = "ImagePath",
                ClaimValue = "/system.jpg",
                UserId = 2
            },
            new AppUserClaim
            {
                Id = 10,
                ClaimType = "UserFirstLastName",
                ClaimValue = "Admin Account",
                UserId = 2
            });
        }
    }
}

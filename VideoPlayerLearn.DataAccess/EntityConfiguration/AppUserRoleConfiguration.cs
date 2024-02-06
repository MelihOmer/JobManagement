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
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                RoleId = 1,
                UserId = 1
            },
            new AppUserRole
            {
                RoleId = 1,
                UserId = 2
            },
            new AppUserRole
            {
                RoleId = 4,
                UserId = 1
            });
        }
    }
}

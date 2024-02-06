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
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();
            builder.ToTable("AspNetRoles");
            

            builder.HasData(new AppRole
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new AppRole
            {
                Id = 2,
                Name = "Teknik",
                NormalizedName = "TEKNIK",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new AppRole
            {
                Id = 3,
                Name = "Standart",
                NormalizedName = "STANDART",
                ConcurrencyStamp = Guid.NewGuid().ToString()
                
            },
            new AppRole
            {
                Id = 4,
                Name = "Egitim",
                NormalizedName = "EGITIM",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

        }
    }
}

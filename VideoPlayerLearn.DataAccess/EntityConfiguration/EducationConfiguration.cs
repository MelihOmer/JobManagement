using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.DataAccess.EntityConfiguration
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasColumnType("ntext");
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.AppUser).WithMany(x => x.Educations).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Department).WithMany(x => x.Educations).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.EducationCategory).WithMany(x => x.Educations).HasForeignKey(x => x.EduEducationCategoryId);
        }
    }
}

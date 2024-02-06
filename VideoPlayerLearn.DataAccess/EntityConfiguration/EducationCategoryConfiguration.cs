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
    public class EducationCategoryConfiguration : IEntityTypeConfiguration<EducationCategory>
    {
        public void Configure(EntityTypeBuilder<EducationCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        }
    }
}

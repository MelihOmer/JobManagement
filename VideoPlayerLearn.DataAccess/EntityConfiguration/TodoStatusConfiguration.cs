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
    public class TodoStatusConfiguration : IEntityTypeConfiguration<TodoStatus>
    {
        public void Configure(EntityTypeBuilder<TodoStatus> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();

            builder.HasData(new TodoStatus()
            {
                Id = 1,
                Description = "Yeni"
            },
            new TodoStatus()
            {
                Id = 2,
                Description = "İnceleniyor"
            },
            new TodoStatus()
            {
                Id = 3,
                Description = "Çözümlendi"
            },
            new TodoStatus()
            {
                Id = 4,
                Description = "Reddedildi"
            });

        }
    }
}

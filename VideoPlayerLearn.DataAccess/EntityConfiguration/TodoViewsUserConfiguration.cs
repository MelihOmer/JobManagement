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
    public class TodoViewsUserConfiguration : IEntityTypeConfiguration<TodoViewsUser>
    {
        public void Configure(EntityTypeBuilder<TodoViewsUser> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AppUser).WithMany(x => x.TodoViewsUsers).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Todo).WithMany(x => x.TodoViewsUsers).HasForeignKey(x => x.TodoId);

        }
    }
}

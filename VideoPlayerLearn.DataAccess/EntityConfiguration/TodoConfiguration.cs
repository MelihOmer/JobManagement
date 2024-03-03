using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.DataAccess.EntityConfiguration
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");



            builder.HasOne(t => t.AppUser).WithMany(u => u.Todos).HasForeignKey(t => t.AppUserId);
            builder.HasOne(t => t.AssignedToUser).WithMany(u => u.AssignedTodos).HasForeignKey(t => t.AssignedToUserId);


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.DataAccess.EntityConfiguration
{
    internal class ClientNotificationConfiguration : IEntityTypeConfiguration<ClientNotification>
    {
        public void Configure(EntityTypeBuilder<ClientNotification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AppUser).WithMany(y => y.ClientNotifications).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x =>x.AssignedToUser).WithMany(y =>y.NotifyAssignedToUser).HasForeignKey(x => x.AssignedToUserId);
            builder.HasOne(x => x.Todo).WithMany(y => y.ClientNotifications).HasForeignKey(x => x.TodoId);
        }
    }
}

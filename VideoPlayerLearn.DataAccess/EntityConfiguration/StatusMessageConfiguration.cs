using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.DataAccess.EntityConfiguration
{
    internal class StatusMessageConfiguration : IEntityTypeConfiguration<StatusMessage>
    {
        public void Configure(EntityTypeBuilder<StatusMessage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.StatusUser).WithMany(x => x.StatusMessages).HasForeignKey(x => x.StatusUserId);
        }
    }
}

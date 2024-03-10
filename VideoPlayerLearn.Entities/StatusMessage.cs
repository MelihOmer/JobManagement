using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class StatusMessage : BaseEntity, IDefaultEntity
    {
        public int StatusUserId { get; set; }
        public AppUser StatusUser { get; set; }
        public string StatusContent { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

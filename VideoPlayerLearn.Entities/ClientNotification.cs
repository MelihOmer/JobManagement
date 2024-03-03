using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class ClientNotification : BaseEntity,IDefaultEntity
    {
        public int TodoId { get; set; }
        public Todo Todo { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool AppUserSeen { get; set; }
        public int? AssignedToUserId { get; set; }
        public AppUser AssignedToUser { get; set; }
        public bool AssignedToUserSeen { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
